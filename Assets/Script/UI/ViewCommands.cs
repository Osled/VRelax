public interface ViewCommands
{
    void RequestRestart();
    void RequestQuit();
    void RequestCameraSwitch(int index);
    void RequestPanelVisibility(bool visible);
}
