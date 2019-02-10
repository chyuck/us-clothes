namespace USClothesWebSite.DTO
{
    public interface IDetailDto<out TMasterDto, TDetailDto> : IDto
        where TMasterDto : IMasterDto<TMasterDto, TDetailDto>
        where TDetailDto : IDetailDto<TMasterDto, TDetailDto>
    {
        TMasterDto MasterDto { get; }
    }
}
