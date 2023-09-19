namespace casa_app_backend.Api.ViewModels
{
    public record RetornoPadrao<T>(bool sucesso, T dados);
}