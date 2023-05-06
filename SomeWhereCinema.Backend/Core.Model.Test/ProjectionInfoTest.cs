using Domain.Model;

namespace Core.Model.Test;

public class ProjectionInfoTest
{
    [Fact]
    public void ProjectionlistCanBeInitialized()
    {
        var projectionInfo = new ProjectionInfo();
        Assert.NotNull(projectionInfo);
        Assert.NotNull(projectionInfo.Id);
        Assert.NotNull(projectionInfo.MovieId);
        Assert.NotNull(projectionInfo.TheaterId);
        Assert.NotNull(projectionInfo.SitAvailableMark);
        
    }
}