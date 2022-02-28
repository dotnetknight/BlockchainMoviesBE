using Nethereum.ABI.FunctionEncoding.Attributes;

namespace Movies.Models.Contracts
{
    public partial class MoviesStructure : MoviesStructureBase { }

    public class MoviesStructureBase
    {
        [Parameter("uint256", "Id", 1)]
        public virtual int Id { get; set; }
        [Parameter("string", "Name", 2)]
        public virtual string Name { get; set; }
        [Parameter("string", "Director", 3)]
        public virtual string Director { get; set; }
    }
}
