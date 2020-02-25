using System;
using RescuerLaApp.Models.ML;

namespace RescuerLaApp.Extensions
{
    public static class MLModelConfigExtension
    {
        public static string GetDockerTag(this MLModelConfig config)
        {
            return $"{config.ApiVersion}.{config.ModelVersion}-{GetTagSuffix(config)}";
        }
        public static string GetDockerTag(uint apiVersion, uint modelVersion, MLModelType type)
        {
            return $"{apiVersion}.{modelVersion}-{GetTagSuffix(type)}";
        }
        public static string GetTagSuffix(this MLModelConfig config)
        {
            switch (config.Type)
            {
                case MLModelType.Cpu:
                    return "cpu";
                case MLModelType.CpuNoAvx:
                    return "cpu-no-avx"; 
                case MLModelType.Gpu:
                    return "gpu";
                //case MLModelType.Tpu:
                //    return "tpu"; 
                //case MLModelType.TpuNoAvx:
                //    return "tpu-no-avx";
                //case MLModelType.TpuCpu:
                //    return "tpu-cpu";
                //case MLModelType.TpuCpuNoAvx:
                //    return "tpu-cpu-no-avx";
                //case MLModelType.TpuGpu:
                //    return "tpu-gpu";
                default:
                    throw new Exception($"Invalid model type: {config.Type.ToString()}.");
            }
        }
        public static string GetTagSuffix(MLModelType type)
        {
            switch (type)
            {
                case MLModelType.Cpu:
                    return "cpu";
                case MLModelType.CpuNoAvx:
                    return "cpu-no-avx"; 
                case MLModelType.Gpu:
                    return "gpu";
                //case MLModelType.Tpu:
                //    return "tpu"; 
                //case MLModelType.TpuNoAvx:
                //    return "tpu-no-avx";
                //case MLModelType.TpuCpu:
                //    return "tpu-cpu";
                //case MLModelType.TpuCpuNoAvx:
                //    return "tpu-cpu-no-avx";
                //case MLModelType.TpuGpu:
                //    return "tpu-gpu";
                default:
                    throw new Exception($"Invalid model type: {type.ToString()}.");
            }
        }
    }
}