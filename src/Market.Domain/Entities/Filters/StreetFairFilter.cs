namespace Market.Domain.Entities.Filters
{
    public record StreetFairFilter(
        string Name,
        string District,
        string Region5,
        string Neighborhood
    );
}