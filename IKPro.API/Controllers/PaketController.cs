﻿using IKPro.Application.DTOs.Paket;
using IKPro.Application.Services.PaketServis;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Authorization;
namespace IKPro.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class PaketController : ControllerBase
    {
        private readonly IPaketServis _paketServis;

        public PaketController(IPaketServis paketServis)
        {
            _paketServis = paketServis;
        }

        // Tüm paketleri listele
        [HttpGet("paket-listele")]
        public async Task<ActionResult<IEnumerable<Paket_Dto>>> TumPaketler()
        {
            var result = await _paketServis.TumPaketleriListeleAsync();
            return Ok(result);
        }

        // Yeni paket ekle
        [HttpPost("paket-ekle")]
        //[Authorize(Roles = "Admin")]
        public async Task<ActionResult<int>> PaketEkle(PaketEkle_Dto paketDto)
        {
            var result = await _paketServis.PaketEkleAsync(paketDto);
            return Ok(result);
        }
    }
}
