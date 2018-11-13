using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IEventConnection
    {
        List<Events> GetEvents();

        List<EventCategoryResponse> GetEventCategories();

        List<EventTypeResponse> GetEventTypes();

        void SaveEvent(SaveEventRequest request);
    }
}
