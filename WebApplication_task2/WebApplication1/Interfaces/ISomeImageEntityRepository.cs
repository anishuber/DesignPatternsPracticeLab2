namespace Task2.Interfaces
{
    public interface ISomeImageEntityRepository
    {
        Task<Uri?> GetImageUrlAsync(Guid id);
        Task SetImageUrlAsync(Guid id, Uri imageUrl);
    }
}
