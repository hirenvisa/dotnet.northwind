using AutoMapper;

namespace Application.Common.Mapper;

public interface IMapFrom<T>
{
    void Mapping(Profile profile);
}
