using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WEBloco.Domain.Model.Entities;
using WEBloco.Domain.Model.Interfaces;

namespace WEBloco.Domain.Services
{
    public class HeroiService : IHeroiService
    {
        private readonly IHeroiRepository _heroiRepository;
        private readonly IBlobService _blobService;

        public HeroiService(IHeroiRepository heroiRepository, IBlobService blobService)
        {
            _heroiRepository = heroiRepository;
            _blobService = blobService;
        }

        public async Task<IEnumerable<Heroi>> GetAllAsync()
        {
            return await _heroiRepository.GetAllAsync();
        }

        public async Task<Heroi> GetByIdAsync(int id)
        {
            return await _heroiRepository.GetByIdAsync(id);
        }

        public async Task InsertAsync(Heroi heroi)
        {
            if (heroi.ImagensBase64.Any())
            {
                var imagens = new List<Imagem>();

                foreach (var imagemBase64 in heroi.ImagensBase64)
                {
                    var blobStream = new MemoryStream(Convert.FromBase64String(imagemBase64));
                    var blobUri = await _blobService.UploadAsync(blobStream);
                    imagens.Add(new Imagem() { FotoUri = blobUri });
                }

                heroi.Imagens = imagens;
            }

            await _heroiRepository.InsertAsync(heroi);
        }
    }
}
