using Asana.Models;
using Asana.Requests;
using Asana.Resources;

namespace Asana.Requests 
{
    /// <summary>
    ///     Webhooks allow an application to be notified of changes. This is in addition
    ///     to the ability to fetch those changes directly as
    ///     [Events](/developers/api-reference/events) - in fact, Webhooks are just a way
    ///     to receive Events via HTTP POST at the time they occur instead of polling for
    ///     them. For services accessible via HTTP this is often vastly more convenient,
    ///     and if events are not too frequent can be significantly more efficient.
    ///     
    ///     In both cases, however, changes are represented as Event objects - refer to
    ///     the [Events documentation](/developers/api-reference/events) for more
    ///     information on what data these events contain.
    ///     
    ///     **NOTE:** While Webhooks send arrays of Event objects to their target, the
    ///     Event objects themselves contain *only IDs*, rather than the actual resource
    ///     they are referencing. So while a normal event you receive via GET /events
    ///     would look like this:
    ///     
    ///         {\
    ///           "resource": {\
    ///             "id": 1337,\
    ///             "name": "My Task"\
    ///           },\
    ///           "parent": null,\
    ///           "created_at": "2013-08-21T18:20:37.972Z",\
    ///           "user": {\
    ///             "id": 1123,\
    ///             "name": "Tom Bizarro"\
    ///           },\
    ///           "action": "changed",\
    ///           "type": "task"\
    ///         }
    ///     
    ///     In a Webhook payload you would instead receive this:
    ///     
    ///         {\
    ///           "resource": 1337,\
    ///           "parent": null,\
    ///           "created_at": "2013-08-21T18:20:37.972Z",\
    ///           "user": 1123,\
    ///           "action": "changed",\
    ///           "type": "task"\
    ///         }
    ///     
    ///     Webhooks themselves contain only the information necessary to deliver the
    ///     events to the desired target as they are generated.
    /// </summary>
    public partial class Webhooks : Resource 
    {
        public Webhooks(Client client)
            : base(client) 
        { }    

        /// <summary>
        ///     Establishing a webhook is a two-part process. First, a simple HTTP POST
        ///     similar to any other resource creation. Since you could have multiple
        ///     webhooks we recommend specifying a unique local id for each target.
        ///     
        ///     Next comes the confirmation handshake. When a webhook is created, we will
        ///     send a test POST to the `target` with an `X-Hook-Secret` header as
        ///     described in the
        ///     [Resthooks Security documentation](http://resthooks.org/docs/security/).
        ///     The target must respond with a `200 OK` and a matching `X-Hook-Secret`
        ///     header to confirm that this webhook subscription is indeed expected.
        ///     
        ///     If you do not acknowledge the webhook's confirmation handshake it will
        ///     fail to setup, and you will receive an error in response to your attempt
        ///     to create it. This means you need to be able to receive and complete the
        ///     webhook *while* the POST request is in-flight.
        /// </summary>
        /// <returns> Request object </returns>        
        public ItemRequest<Webhook> Create() 
        {
            return new ItemRequest<Webhook>(this.Client, "/webhooks", "POST");
        }    

        /// <summary>
        ///     Returns the compact representation of all webhooks your app has
        ///     registered for the authenticated user in the given workspace.
        /// </summary>
        /// <returns> Request object </returns>        
        public CollectionRequest<Webhook> GetAll() 
        {
            return new CollectionRequest<Webhook>(this.Client, "/webhooks", "GET");
        }    

        /// <summary>
        ///     Returns the full record for the given webhook.
        /// </summary>
        /// <param name="webhook">
        ///     The webhook to get. 
        /// </param> 
        /// <returns> Request object </returns>        
        public ItemRequest<Webhook> GetById(string webhook) 
        {
            string path = string.Format("/webhooks/%s", webhook);
            return new ItemRequest<Webhook>(this.Client, path, "GET");
        }    

        /// <summary>
        ///     This method permanently removes a webhook. Note that it may be possible
        ///     to receive a request that was already in flight after deleting the
        ///     webhook, but no further requests will be issued.
        /// </summary>
        /// <param name="webhook">
        ///     The webhook to delete. 
        /// </param> 
        /// <returns> Request object </returns>        
        public ItemRequest<Webhook> DeleteById(string webhook) 
        {
            string path = string.Format("/webhooks/%s", webhook);
            return new ItemRequest<Webhook>(this.Client, path, "DELETE");
        }
    }
}