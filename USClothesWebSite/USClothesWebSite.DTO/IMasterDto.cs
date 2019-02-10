namespace USClothesWebSite.DTO
{
    public interface IMasterDto<TMasterDto, out TDetailDto> : IDto
        where TMasterDto : IMasterDto<TMasterDto, TDetailDto>
        where TDetailDto : IDetailDto<TMasterDto, TDetailDto>
    {
        TDetailDto[] DetailDtos { get; }
    }
}
