using System.Threading.Tasks;
using Amazon;
using Microsoft.AspNetCore.Http;
using Amazon.S3;
using Amazon.S3.Model;
using PutObjectRequest = Amazon.S3.Model.PutObjectRequest;


namespace Netfritz.Services
{
    public class S3StorageService : IS3StorageService
    {
        private const string AwsAccessKeyId = "AKIAV4KG3AUR4GZEHHM3";
        private const string AwsSecretAccessKey = "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";
        private const string BucketName = "uploadexamplevilela";
        
        private readonly RegionEndpoint _regionEndpoint = RegionEndpoint.SAEast1;
        private readonly AmazonS3Client _client;

        private static  S3StorageService _instance;
        
        private S3StorageService()
        {
            _client = new AmazonS3Client(
                awsAccessKeyId: AwsAccessKeyId,
                awsSecretAccessKey: AwsSecretAccessKey,
                region: _regionEndpoint
            );
        }

        public static S3StorageService GetInstance()
        {
            if (_instance is null)
            {
                _instance = new S3StorageService();
            }
            return _instance;
        }
        
        public async Task<string> UploadImagem(IFormFile file, string fitaId)
        {
            var putObjectRequest = new PutObjectRequest()
            {
                BucketName = BucketName,
                Key = fitaId,
                InputStream = file.OpenReadStream(),
                ContentType = file.ContentType,
                CannedACL = S3CannedACL.PublicRead
            };

            await _client.PutObjectAsync(putObjectRequest);
            
            return $"https://{BucketName}.s3-{_regionEndpoint.SystemName}.amazonaws.com/{fitaId}";
        }
    }
}