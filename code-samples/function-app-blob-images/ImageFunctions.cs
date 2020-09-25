using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats;
using SixLabors.ImageSharp.Processing;

namespace function_app_blob_images
{
    public static class ImageFunctions
    {
        [FunctionName("ImageFlip")]
        public static async Task Run(
            [BlobTrigger("uploaded/{blobName}")] Stream inputBlob,
            string blobName,
            [Blob("vflip/{blobName}", FileAccess.Write)] Stream outputHFlipBlob,
            [Blob("hflip/{blobName}", FileAccess.Write)] Stream outputVFlipBlob,
            [Blob("thumbnail/{blobName}", FileAccess.Write)] Stream outputThumbnailBlob,
            ILogger log)
        {
            using (var image = Image.Load(inputBlob))
            {
                await FlipAsync(image, outputHFlipBlob, FlipMode.Horizontal);
                await FlipAsync(image, outputVFlipBlob, FlipMode.Vertical);
                await GenerateThumbnailAsync(image, outputThumbnailBlob);
            }
        }

        private static async Task FlipAsync(Image input, Stream output, FlipMode mode)
        {
            input.Mutate(img => img.Flip(mode));
            await input.SaveAsPngAsync(output);
        }

        private static async Task GenerateThumbnailAsync(Image input, Stream output)
        {
            input.Mutate(img => img.Resize(32, 32)); // arbitrary size
            await input.SaveAsPngAsync(output);
        }
    }
}
