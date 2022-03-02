using Movies.Models.Contracts;
using Nethereum.Contracts.ContractHandlers;
using Nethereum.Hex.HexTypes;
using Nethereum.RPC.Eth.DTOs;
using System.Numerics;

namespace Movies.Services
{
    public partial class MoviesService
    {
        protected Nethereum.Web3.Web3 Web3 { get; }

        public ContractHandler ContractHandler { get; }

        public MoviesService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<TransactionReceipt> AddMovieRequestAndWaitForReceiptAsync(MoviesStructure movie, string senderAddress, CancellationTokenSource cancellationToken = null)
        {
            var addMovieFunction = new AddMovieFunction
            {
                Movie = movie,
                GasPrice = new HexBigInteger(new BigInteger(400000)),
                FromAddress = senderAddress,
            };

            return ContractHandler.SendRequestAndWaitForReceiptAsync(addMovieFunction, cancellationToken);
        }

        public Task<GetMoviesOutputDTO> GetMoviesQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetMoviesFunction, GetMoviesOutputDTO>(null, blockParameter);
        }
    }
}