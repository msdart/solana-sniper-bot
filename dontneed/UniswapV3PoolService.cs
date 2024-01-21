using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts.ContractHandlers;
using Nethereum.Contracts;
using System.Threading;
using Nethereum.Uniswap.Contracts.UniswapV3Pool.ContractDefinition;

namespace Nethereum.Uniswap.Contracts.UniswapV3Pool
{
    public partial class UniswapV3PoolService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, UniswapV3PoolDeployment uniswapV3PoolDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<UniswapV3PoolDeployment>().SendRequestAndWaitForReceiptAsync(uniswapV3PoolDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, UniswapV3PoolDeployment uniswapV3PoolDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<UniswapV3PoolDeployment>().SendRequestAsync(uniswapV3PoolDeployment);
        }

        public static async Task<UniswapV3PoolService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, UniswapV3PoolDeployment uniswapV3PoolDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, uniswapV3PoolDeployment, cancellationTokenSource);
            return new UniswapV3PoolService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public UniswapV3PoolService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<string> BurnRequestAsync(BurnFunction burnFunction)
        {
             return ContractHandler.SendRequestAsync(burnFunction);
        }

        public Task<TransactionReceipt> BurnRequestAndWaitForReceiptAsync(BurnFunction burnFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(burnFunction, cancellationToken);
        }

        public Task<string> BurnRequestAsync(int tickLower,  int tickUpper, BigInteger amount)
        {
            var burnFunction = new BurnFunction();
                burnFunction.TickLower = tickLower;
                burnFunction.TickUpper = tickUpper;
                burnFunction.Amount = amount;
            
             return ContractHandler.SendRequestAsync(burnFunction);
        }

        public Task<TransactionReceipt> BurnRequestAndWaitForReceiptAsync(int tickLower, int tickUpper, BigInteger amount, CancellationTokenSource cancellationToken = null)
        {
            var burnFunction = new BurnFunction();
                burnFunction.TickLower = tickLower;
                burnFunction.TickUpper = tickUpper;
                burnFunction.Amount = amount;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(burnFunction, cancellationToken);
        }

        public Task<string> CollectRequestAsync(CollectFunction collectFunction)
        {
             return ContractHandler.SendRequestAsync(collectFunction);
        }

        public Task<TransactionReceipt> CollectRequestAndWaitForReceiptAsync(CollectFunction collectFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(collectFunction, cancellationToken);
        }

        public Task<string> CollectRequestAsync(string recipient, int tickLower, int  tickUpper, BigInteger amount0Requested, BigInteger amount1Requested)
        {
            var collectFunction = new CollectFunction();
                collectFunction.Recipient = recipient;
                collectFunction.TickLower = tickLower;
                collectFunction.TickUpper = tickUpper;
                collectFunction.Amount0Requested = amount0Requested;
                collectFunction.Amount1Requested = amount1Requested;
            
             return ContractHandler.SendRequestAsync(collectFunction);
        }

        public Task<TransactionReceipt> CollectRequestAndWaitForReceiptAsync(string recipient, int  tickLower, int tickUpper, BigInteger amount0Requested, BigInteger amount1Requested, CancellationTokenSource cancellationToken = null)
        {
            var collectFunction = new CollectFunction();
                collectFunction.Recipient = recipient;
                collectFunction.TickLower = tickLower;
                collectFunction.TickUpper = tickUpper;
                collectFunction.Amount0Requested = amount0Requested;
                collectFunction.Amount1Requested = amount1Requested;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(collectFunction, cancellationToken);
        }

        public Task<string> CollectProtocolRequestAsync(CollectProtocolFunction collectProtocolFunction)
        {
             return ContractHandler.SendRequestAsync(collectProtocolFunction);
        }

        public Task<TransactionReceipt> CollectProtocolRequestAndWaitForReceiptAsync(CollectProtocolFunction collectProtocolFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(collectProtocolFunction, cancellationToken);
        }

        public Task<string> CollectProtocolRequestAsync(string recipient, BigInteger amount0Requested, BigInteger amount1Requested)
        {
            var collectProtocolFunction = new CollectProtocolFunction();
                collectProtocolFunction.Recipient = recipient;
                collectProtocolFunction.Amount0Requested = amount0Requested;
                collectProtocolFunction.Amount1Requested = amount1Requested;
            
             return ContractHandler.SendRequestAsync(collectProtocolFunction);
        }

        public Task<TransactionReceipt> CollectProtocolRequestAndWaitForReceiptAsync(string recipient, BigInteger amount0Requested, BigInteger amount1Requested, CancellationTokenSource cancellationToken = null)
        {
            var collectProtocolFunction = new CollectProtocolFunction();
                collectProtocolFunction.Recipient = recipient;
                collectProtocolFunction.Amount0Requested = amount0Requested;
                collectProtocolFunction.Amount1Requested = amount1Requested;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(collectProtocolFunction, cancellationToken);
        }

        public Task<string> FactoryQueryAsync(FactoryFunction factoryFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<FactoryFunction, string>(factoryFunction, blockParameter);
        }

        
        public Task<string> FactoryQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<FactoryFunction, string>(null, blockParameter);
        }

        public Task<int> FeeQueryAsync(FeeFunction feeFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<FeeFunction, int>(feeFunction, blockParameter);
        }

        
        public Task<int> FeeQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<FeeFunction, int>(null, blockParameter);
        }

        public Task<BigInteger> FeeGrowthGlobal0X128QueryAsync(FeeGrowthGlobal0X128Function feeGrowthGlobal0X128Function, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<FeeGrowthGlobal0X128Function, BigInteger>(feeGrowthGlobal0X128Function, blockParameter);
        }

        
        public Task<BigInteger> FeeGrowthGlobal0X128QueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<FeeGrowthGlobal0X128Function, BigInteger>(null, blockParameter);
        }

        public Task<BigInteger> FeeGrowthGlobal1X128QueryAsync(FeeGrowthGlobal1X128Function feeGrowthGlobal1X128Function, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<FeeGrowthGlobal1X128Function, BigInteger>(feeGrowthGlobal1X128Function, blockParameter);
        }

        
        public Task<BigInteger> FeeGrowthGlobal1X128QueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<FeeGrowthGlobal1X128Function, BigInteger>(null, blockParameter);
        }

        public Task<string> FlashRequestAsync(FlashFunction flashFunction)
        {
             return ContractHandler.SendRequestAsync(flashFunction);
        }

        public Task<TransactionReceipt> FlashRequestAndWaitForReceiptAsync(FlashFunction flashFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(flashFunction, cancellationToken);
        }

        public Task<string> FlashRequestAsync(string recipient, BigInteger amount0, BigInteger amount1, byte[] data)
        {
            var flashFunction = new FlashFunction();
                flashFunction.Recipient = recipient;
                flashFunction.Amount0 = amount0;
                flashFunction.Amount1 = amount1;
                flashFunction.Data = data;
            
             return ContractHandler.SendRequestAsync(flashFunction);
        }

        public Task<TransactionReceipt> FlashRequestAndWaitForReceiptAsync(string recipient, BigInteger amount0, BigInteger amount1, byte[] data, CancellationTokenSource cancellationToken = null)
        {
            var flashFunction = new FlashFunction();
                flashFunction.Recipient = recipient;
                flashFunction.Amount0 = amount0;
                flashFunction.Amount1 = amount1;
                flashFunction.Data = data;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(flashFunction, cancellationToken);
        }

        public Task<string> IncreaseObservationCardinalityNextRequestAsync(IncreaseObservationCardinalityNextFunction increaseObservationCardinalityNextFunction)
        {
             return ContractHandler.SendRequestAsync(increaseObservationCardinalityNextFunction);
        }

        public Task<TransactionReceipt> IncreaseObservationCardinalityNextRequestAndWaitForReceiptAsync(IncreaseObservationCardinalityNextFunction increaseObservationCardinalityNextFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(increaseObservationCardinalityNextFunction, cancellationToken);
        }

        public Task<string> IncreaseObservationCardinalityNextRequestAsync(ushort observationCardinalityNext)
        {
            var increaseObservationCardinalityNextFunction = new IncreaseObservationCardinalityNextFunction();
                increaseObservationCardinalityNextFunction.ObservationCardinalityNext = observationCardinalityNext;
            
             return ContractHandler.SendRequestAsync(increaseObservationCardinalityNextFunction);
        }

        public Task<TransactionReceipt> IncreaseObservationCardinalityNextRequestAndWaitForReceiptAsync(ushort observationCardinalityNext, CancellationTokenSource cancellationToken = null)
        {
            var increaseObservationCardinalityNextFunction = new IncreaseObservationCardinalityNextFunction();
                increaseObservationCardinalityNextFunction.ObservationCardinalityNext = observationCardinalityNext;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(increaseObservationCardinalityNextFunction, cancellationToken);
        }

        public Task<string> InitializeRequestAsync(InitializeFunction initializeFunction)
        {
             return ContractHandler.SendRequestAsync(initializeFunction);
        }

        public Task<TransactionReceipt> InitializeRequestAndWaitForReceiptAsync(InitializeFunction initializeFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(initializeFunction, cancellationToken);
        }

        public Task<string> InitializeRequestAsync(BigInteger sqrtPriceX96)
        {
            var initializeFunction = new InitializeFunction();
                initializeFunction.SqrtPriceX96 = sqrtPriceX96;
            
             return ContractHandler.SendRequestAsync(initializeFunction);
        }

        public Task<TransactionReceipt> InitializeRequestAndWaitForReceiptAsync(BigInteger sqrtPriceX96, CancellationTokenSource cancellationToken = null)
        {
            var initializeFunction = new InitializeFunction();
                initializeFunction.SqrtPriceX96 = sqrtPriceX96;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(initializeFunction, cancellationToken);
        }

        public Task<BigInteger> LiquidityQueryAsync(LiquidityFunction liquidityFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<LiquidityFunction, BigInteger>(liquidityFunction, blockParameter);
        }

        
        public Task<BigInteger> LiquidityQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<LiquidityFunction, BigInteger>(null, blockParameter);
        }

        public Task<BigInteger> MaxLiquidityPerTickQueryAsync(MaxLiquidityPerTickFunction maxLiquidityPerTickFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<MaxLiquidityPerTickFunction, BigInteger>(maxLiquidityPerTickFunction, blockParameter);
        }

        
        public Task<BigInteger> MaxLiquidityPerTickQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<MaxLiquidityPerTickFunction, BigInteger>(null, blockParameter);
        }

        public Task<string> MintRequestAsync(MintFunction mintFunction)
        {
             return ContractHandler.SendRequestAsync(mintFunction);
        }

        public Task<TransactionReceipt> MintRequestAndWaitForReceiptAsync(MintFunction mintFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(mintFunction, cancellationToken);
        }

        public Task<string> MintRequestAsync(string recipient, int tickLower, int tickUpper, BigInteger amount, byte[] data)
        {
            var mintFunction = new MintFunction();
                mintFunction.Recipient = recipient;
                mintFunction.TickLower = tickLower;
                mintFunction.TickUpper = tickUpper;
                mintFunction.Amount = amount;
                mintFunction.Data = data;
            
             return ContractHandler.SendRequestAsync(mintFunction);
        }

        public Task<TransactionReceipt> MintRequestAndWaitForReceiptAsync(string recipient, int tickLower, int tickUpper, BigInteger amount, byte[] data, CancellationTokenSource cancellationToken = null)
        {
            var mintFunction = new MintFunction();
                mintFunction.Recipient = recipient;
                mintFunction.TickLower = tickLower;
                mintFunction.TickUpper = tickUpper;
                mintFunction.Amount = amount;
                mintFunction.Data = data;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(mintFunction, cancellationToken);
        }

        public Task<ObservationsOutputDTO> ObservationsQueryAsync(ObservationsFunction observationsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<ObservationsFunction, ObservationsOutputDTO>(observationsFunction, blockParameter);
        }

        public Task<ObservationsOutputDTO> ObservationsQueryAsync(BigInteger index, BlockParameter blockParameter = null)
        {
            var observationsFunction = new ObservationsFunction();
                observationsFunction.Index = index;
            
            return ContractHandler.QueryDeserializingToObjectAsync<ObservationsFunction, ObservationsOutputDTO>(observationsFunction, blockParameter);
        }

        public Task<ObserveOutputDTO> ObserveQueryAsync(ObserveFunction observeFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<ObserveFunction, ObserveOutputDTO>(observeFunction, blockParameter);
        }

        public Task<ObserveOutputDTO> ObserveQueryAsync(List<uint> secondsAgos, BlockParameter blockParameter = null)
        {
            var observeFunction = new ObserveFunction();
                observeFunction.SecondsAgos = secondsAgos;
            
            return ContractHandler.QueryDeserializingToObjectAsync<ObserveFunction, ObserveOutputDTO>(observeFunction, blockParameter);
        }

        public Task<PositionsOutputDTO> PositionsQueryAsync(PositionsFunction positionsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<PositionsFunction, PositionsOutputDTO>(positionsFunction, blockParameter);
        }

        public Task<PositionsOutputDTO> PositionsQueryAsync(byte[] key, BlockParameter blockParameter = null)
        {
            var positionsFunction = new PositionsFunction();
                positionsFunction.Key = key;
            
            return ContractHandler.QueryDeserializingToObjectAsync<PositionsFunction, PositionsOutputDTO>(positionsFunction, blockParameter);
        }

        public Task<ProtocolFeesOutputDTO> ProtocolFeesQueryAsync(ProtocolFeesFunction protocolFeesFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<ProtocolFeesFunction, ProtocolFeesOutputDTO>(protocolFeesFunction, blockParameter);
        }

        public Task<ProtocolFeesOutputDTO> ProtocolFeesQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<ProtocolFeesFunction, ProtocolFeesOutputDTO>(null, blockParameter);
        }

        public Task<string> SetFeeProtocolRequestAsync(SetFeeProtocolFunction setFeeProtocolFunction)
        {
             return ContractHandler.SendRequestAsync(setFeeProtocolFunction);
        }

        public Task<TransactionReceipt> SetFeeProtocolRequestAndWaitForReceiptAsync(SetFeeProtocolFunction setFeeProtocolFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setFeeProtocolFunction, cancellationToken);
        }

        public Task<string> SetFeeProtocolRequestAsync(byte feeProtocol0, byte feeProtocol1)
        {
            var setFeeProtocolFunction = new SetFeeProtocolFunction();
                setFeeProtocolFunction.FeeProtocol0 = feeProtocol0;
                setFeeProtocolFunction.FeeProtocol1 = feeProtocol1;
            
             return ContractHandler.SendRequestAsync(setFeeProtocolFunction);
        }

        public Task<TransactionReceipt> SetFeeProtocolRequestAndWaitForReceiptAsync(byte feeProtocol0, byte feeProtocol1, CancellationTokenSource cancellationToken = null)
        {
            var setFeeProtocolFunction = new SetFeeProtocolFunction();
                setFeeProtocolFunction.FeeProtocol0 = feeProtocol0;
                setFeeProtocolFunction.FeeProtocol1 = feeProtocol1;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setFeeProtocolFunction, cancellationToken);
        }

        public Task<Slot0OutputDTO> Slot0QueryAsync(Slot0Function slot0Function, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<Slot0Function, Slot0OutputDTO>(slot0Function, blockParameter);
        }

        public Task<Slot0OutputDTO> Slot0QueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<Slot0Function, Slot0OutputDTO>(null, blockParameter);
        }

        public Task<SnapshotCumulativesInsideOutputDTO> SnapshotCumulativesInsideQueryAsync(SnapshotCumulativesInsideFunction snapshotCumulativesInsideFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<SnapshotCumulativesInsideFunction, SnapshotCumulativesInsideOutputDTO>(snapshotCumulativesInsideFunction, blockParameter);
        }

        public Task<SnapshotCumulativesInsideOutputDTO> SnapshotCumulativesInsideQueryAsync(int tickLower, int tickUpper, BlockParameter blockParameter = null)
        {
            var snapshotCumulativesInsideFunction = new SnapshotCumulativesInsideFunction();
                snapshotCumulativesInsideFunction.TickLower = tickLower;
                snapshotCumulativesInsideFunction.TickUpper = tickUpper;
            
            return ContractHandler.QueryDeserializingToObjectAsync<SnapshotCumulativesInsideFunction, SnapshotCumulativesInsideOutputDTO>(snapshotCumulativesInsideFunction, blockParameter);
        }

        public Task<string> SwapRequestAsync(SwapFunction swapFunction)
        {
             return ContractHandler.SendRequestAsync(swapFunction);
        }

        public Task<TransactionReceipt> SwapRequestAndWaitForReceiptAsync(SwapFunction swapFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(swapFunction, cancellationToken);
        }

        public Task<string> SwapRequestAsync(string recipient, bool zeroForOne, BigInteger amountSpecified, BigInteger sqrtPriceLimitX96, byte[] data)
        {
            var swapFunction = new SwapFunction();
                swapFunction.Recipient = recipient;
                swapFunction.ZeroForOne = zeroForOne;
                swapFunction.AmountSpecified = amountSpecified;
                swapFunction.SqrtPriceLimitX96 = sqrtPriceLimitX96;
                swapFunction.Data = data;
            
             return ContractHandler.SendRequestAsync(swapFunction);
        }

        public Task<TransactionReceipt> SwapRequestAndWaitForReceiptAsync(string recipient, bool zeroForOne, BigInteger amountSpecified, BigInteger sqrtPriceLimitX96, byte[] data, CancellationTokenSource cancellationToken = null)
        {
            var swapFunction = new SwapFunction();
                swapFunction.Recipient = recipient;
                swapFunction.ZeroForOne = zeroForOne;
                swapFunction.AmountSpecified = amountSpecified;
                swapFunction.SqrtPriceLimitX96 = sqrtPriceLimitX96;
                swapFunction.Data = data;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(swapFunction, cancellationToken);
        }

        public Task<BigInteger> TickBitmapQueryAsync(TickBitmapFunction tickBitmapFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<TickBitmapFunction, BigInteger>(tickBitmapFunction, blockParameter);
        }

        
        public Task<BigInteger> TickBitmapQueryAsync(short wordPosition, BlockParameter blockParameter = null)
        {
            var tickBitmapFunction = new TickBitmapFunction();
                tickBitmapFunction.WordPosition = wordPosition;
            
            return ContractHandler.QueryAsync<TickBitmapFunction, BigInteger>(tickBitmapFunction, blockParameter);
        }

        public Task<int> TickSpacingQueryAsync(TickSpacingFunction tickSpacingFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<TickSpacingFunction, int>(tickSpacingFunction, blockParameter);
        }

        
        public Task<int> TickSpacingQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<TickSpacingFunction, int >(null, blockParameter);
        }

        public Task<TicksOutputDTO> TicksQueryAsync(TicksFunction ticksFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<TicksFunction, TicksOutputDTO>(ticksFunction, blockParameter);
        }

        public Task<TicksOutputDTO> TicksQueryAsync(int tick, BlockParameter blockParameter = null)
        {
            var ticksFunction = new TicksFunction();
                ticksFunction.Tick = tick;
            
            return ContractHandler.QueryDeserializingToObjectAsync<TicksFunction, TicksOutputDTO>(ticksFunction, blockParameter);
        }

        public Task<string> Token0QueryAsync(Token0Function token0Function, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<Token0Function, string>(token0Function, blockParameter);
        }

        
        public Task<string> Token0QueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<Token0Function, string>(null, blockParameter);
        }

        public Task<string> Token1QueryAsync(Token1Function token1Function, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<Token1Function, string>(token1Function, blockParameter);
        }

        
        public Task<string> Token1QueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<Token1Function, string>(null, blockParameter);
        }
    }
}
