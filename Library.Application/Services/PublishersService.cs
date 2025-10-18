using Library.Application.Interfaces;
using Library.Domain.Entities;

namespace Library.Application.Services;

public class PublishersService
{
    private readonly IPublishersRepository _repo;
       private readonly Random _random = new Random();
    public PublishersService(IPublishersRepository repo)
    {
        _repo = repo;
    }

    public Task<IEnumerable<Publishers>> GetPublishersAsync()
    {
        return _repo.GetAllAsync();
    }
    public Task<Publishers?> GetPublisherAsync(int id)
    {
        return _repo.GetByIdAsync(id);
    }
    public Task<Publishers> AddPublisherAsync(Publishers publisher)
    {
        int publisherId;
        do
        {
            publisherId = _random.Next(1000, 9999);
        }
        while (_repo.ExistsByPublisherIdAsync(publisherId).Result);
        publisher.publisher_id = publisherId;
        publisher.create_date = DateTime.UtcNow;       

        return _repo.AddAsync(publisher);
    }
    public Task<Publishers?> UpdatePublisherAsync(Publishers publisher)
    {
        return _repo.UpdateAsync(publisher);
    }
    public Task<bool> DeletePublisherAsync(int id)
    {
        return _repo.DeleteAsync(id);
    }
}