using Nethereum.ABI.FunctionEncoding.Attributes;
using System.Numerics;

namespace Movies.Models.Contracts
{
    public partial class ActorsStruct : ActorsStructBase { }

    public class ActorsStructBase
    {
        [Parameter("uint256", "Id", 1)]
        public virtual int Id { get; set; }

        [Parameter("string", "Name", 2)]
        public virtual string Name { get; set; }
    }
}