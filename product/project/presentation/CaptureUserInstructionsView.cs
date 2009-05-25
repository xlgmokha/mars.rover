namespace mars.rover.presentation
{
    public interface CaptureUserInstructionsView
    {
        void attach_to(CaptureUserInstructionsPresenter presenter);
        void display(string location);
    }
}