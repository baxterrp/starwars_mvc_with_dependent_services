using StarWarsFanSite.Entities;
using System.Threading.Tasks;

namespace StarWarsFanSite.Data
{
    public interface ICharacterRepository
    {
        Task SaveCharacter(Character character);
        Task<Character> GetCharacter(string characterId);
    }
}
