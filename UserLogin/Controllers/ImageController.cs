using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UserLogin.Models;


namespace UserLogin.Controllers
{
    public class ImageController : Controller
    {
        private readonly DemoDbcontext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;


        public ImageController(DemoDbcontext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Image
        public async Task<IActionResult> Index()
        {
            return _context.TblUserDetails != null ?
                        View(await _context.TblUserDetails.ToListAsync()) :
                        Problem("Entity set 'DemoDbcontext.TblUserDetails'  is null.");
        }

        // GET: Image/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TblUserDetails == null)
            {
                return NotFound();
            }

            var tblUserDetail = await _context.TblUserDetails
                .FirstOrDefaultAsync(m => m.MobileNum == id);
            if (tblUserDetail == null)
            {
                return NotFound();
            }

            return View(tblUserDetail);
        }

        // GET: Image/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Image/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MobileNum,Name,Address,EmailId,DisplayImage")] TblUserDetail tblUserDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblUserDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblUserDetail);
        }









        private bool TblUserDetailExists(int id)
        {
            return (_context.TblUserDetails?.Any(e => e.MobileNum == id)).GetValueOrDefault();
        }
    }
}
