# Markdown File

Just to summarize the changes, there are **2 main flavors of requests: those that return a value, and those that do not.** The ones that do not now implement ```IRequest<T>``` where T : Unit. 

This was to unify requests and handlers into one single type. The diverging types broke the pipeline for many containers, the unification means you can use pipelines for any kind of request.

It forced me to add the Unit type in all cases, so I've added some helper classes for you.
```csharp
- IRequestHandler<T> - implement this and you will return Task<Unit>.
- AsyncRequestHandler<T> - inherit this and you will return Task.
- RequestHandler<T> - inherit this and you will return nothing (void).

For requests that do return values:

- IRequestHandler<T, U> - you will return Task<U>
- RequestHandler<T, U> - you will return U
```
I got rid of the AsyncRequestHandler<T, U> because it really wasn't doing anything after the consolidation, a redundant base class.