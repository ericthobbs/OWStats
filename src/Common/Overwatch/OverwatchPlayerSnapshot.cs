using System.Threading.Tasks;

namespace Common.Overwatch
{
    public class PlayerSnapshot
    {
        public string RawHtml { get; private set; }

        public PlayerSnapshot(string html)
        {
            RawHtml = html;
        }

        public async Task<bool> ParseHtml()
        {
            return false;
        }
    }
}
