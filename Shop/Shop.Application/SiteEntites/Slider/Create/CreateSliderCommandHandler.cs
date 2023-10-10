using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Shop.Application._Utilities;
using Shop.Domain.SiteEntites.Repositories;

namespace Shop.Application.SiteEntites.Slider.Create
{
    internal class CreateSliderCommandHandler : IBaseCommandHandler<CreateSliderCommand>
    {
        private readonly ISliderRepository _repository;
        private readonly IFileService _fileService;

        public CreateSliderCommandHandler(ISliderRepository repository, IFileService fileService)
        {
            _repository = repository;
            _fileService = fileService;
        }

        public async Task<OperationResult> Handle(CreateSliderCommand request, CancellationToken cancellationToken)
        {
            var imageName = await _fileService.SaveFileAndGenerateName(request.ImageFile, Directories.SliderImages);
            var slider = new Shop.Domain.SiteEntites.Slider(request.Title, request.Link, imageName);
            _repository.Add(slider);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}
