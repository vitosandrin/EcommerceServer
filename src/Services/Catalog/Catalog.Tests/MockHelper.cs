namespace Catalog.Tests;
public static class MockHelper
{
    public static void SetupQuery<T>(this Mock<IDocumentSession> mockSession, IEnumerable<T> data) where T : class
    {
        var queryable = data.AsQueryable();

        var mockMartenQueryable = new Mock<IMartenQueryable<T>>();
        mockMartenQueryable.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryable.Provider);
        mockMartenQueryable.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryable.Expression);
        mockMartenQueryable.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
        mockMartenQueryable.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(queryable.GetEnumerator());

        mockSession.Setup(s => s.Query<T>()).Returns(mockMartenQueryable.Object);
    }
}