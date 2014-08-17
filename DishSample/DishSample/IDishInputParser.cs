using System.Collections.Generic;

namespace DishSample
{
    public interface IDishInputParser
    {
        void Process();
        bool Validate();
        List<int> OrderNumbers { get; set; }
        string TimeOfTheDay { get; set; }
    }
}
