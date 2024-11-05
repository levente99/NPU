using NicePartUsage.Domain.Models;

namespace NicePartUsage.Application.Interfaces.Services
{
    public interface IElementService
    {
        Task<List<Element>> GetElements();

        Task<Element> GetElement(int id);

        Task<Element> AddElement(Element element);

        Task<Element> UpdateElement(int id, Element element);

        Task<bool> DeleteElement(int id, Element element);
    }
}
