using System.Threading.Tasks;

namespace ConsoleApp
{
    public interface IDay
    {
        string[] RawInput { get; set; }
        
        Task Part1Async();

        Task Part2Async();
    }
}