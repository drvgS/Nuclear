using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nuclear.Dtos.Category;
using Nuclear.Dtos.Post;
using Nuclear.Dtos.Topic;

namespace Nuclear.SignalR
{
    public interface IClientHubEvents
    {
        Task CategoryCreatedEvent(CategoryDto category);
        Task CategoryDeletedEvent(long categoryId);
        Task TopicCreatedEvent(TopicDto topic);
        Task TopicDeletedEvent(long topicId);
        Task ReplyCreatedEvent(PostDto post);
    }
}
