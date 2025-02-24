using IKPro.Application.DTOs.Sirket;
using IKPro.Application.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKPro.Application.Services.SirketServis
{
    public interface ISirketServis
    {
        public Task<int> SirketEkleAsync(SirketEkle_Dto sirket);
        public Task<bool> SirketGuncelleAsync(Sirket_Dto sirket);
        public Task<bool> SirketSilAsync(int id); // pasif silme yapılıcak
        public Task<IEnumerable<Sirket_Dto>> TumSirketleriListeleAsync();
        public Task<Sirket_Dto> SirketDetayGetirAsync(int id);
    }
}
