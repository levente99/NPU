using Microsoft.EntityFrameworkCore;
using NicePartUsage.Application.Interfaces;
using NicePartUsage.Application.Interfaces.Repositories;
using NicePartUsage.Application.Interfaces.Services;
using NicePartUsage.Domain.Models;

namespace NicePartUsage.Application.Services
{
    public class ElementService(IElementRepository elementRepository, IUnitOfWork unitOfWork) : IElementService
    {
        private readonly IElementRepository _elementRepository = elementRepository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Element> AddElement(Element element)
        {
            await _elementRepository.AddAsync(element);
            await _unitOfWork.SaveChangesAsync();

            return element;
        }

        public async Task<Element> GetElement(int id)
        {
            return await _elementRepository.GetByIdAsync(id);
        }

        public async Task<List<Element>> GetElements()
        {
            return await _elementRepository.GetAll().ToListAsync();
        }

        public async Task<Element> UpdateElement(int id, Element element)
        {
            var entity = await _elementRepository.GetByIdAsync(id);

            if (entity == null)
                return null;
           
            _elementRepository.Update(element);

            await _unitOfWork.SaveChangesAsync();

            return element;
        }

        public async Task<bool> DeleteElement(int id, Element element)
        {
            var entity = await _elementRepository.GetByIdAsync(id);

            if (entity == null)
                return false;

            _elementRepository.Delete(element);

            await _unitOfWork.SaveChangesAsync();

            return true;
        }
    }
}
