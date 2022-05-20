using Model;
using System;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;

namespace ViewModel
{
    public class MainWindowViewModel : ViewModelBase

    {
        //PRIVATE
        //Connection with Model layer.
        private readonly ModelAPI ModelLayer;
        //Wil help us determine when the simulation is started and decide what actions we can take (start/stop).
        private bool isReadyToBegin = true;
        //Controllers telling us about the state of the game;
        private bool isPaused = false;
        private bool isResumed = false;
        //Controllers telling us whether we can change speed.
        private bool canIncrease = true;
        private bool canDecrease = true;
        private Task movingTask;

        //Content of the box represented by string.
        private string box_content;
        //We have two concurrent tasks and twoe threads to deal with them.

        //PUBLIC

        //Cancellation token.
        public CancellationToken Token { get; set; }

        //Collection of observable spheres.
        public ObservableCollection<ISphere> Spheres { get; set; }

        //ICommand for all buttons the user can interact with.
        public ICommand BeginSimulationAction { get; set; }
        public ICommand ResumeSimulationAction { get; set; }
        public ICommand PauseSimulationAction { get; set; }
        public ICommand IncreaseSpeedAction { get; set; }
        public ICommand DecreaseSpeedAction { get; set; }

        //How many spheres will be placed.
        public int HowMany { get; set; }

        ////This property works with box_content field. It hands ofer that fields value and allows us to modify it and notify about it being changed.
        public string TextBox{get { return box_content; }
            set { box_content = value; RaisePropertyChanged("TextBox"); }}

        //This property works with notStarted field. It hands ofer that fields value and allows us to modify it and notify about it being changed.
        public bool IsReadyToBegin {get{return isReadyToBegin;}
            set{isReadyToBegin = value; RaisePropertyChanged("isReadyToBegin");}}

        //Controllers for pause and resume.
        public bool CanPause{get{return isResumed;}
            set{isResumed = value; RaisePropertyChanged("CanPause");}}
        public bool CanResume{get{return isPaused;}
            set{isPaused = value; RaisePropertyChanged("CanResume");}}
        //Controllers for changing speed
        public bool CanIncrease{get{return canIncrease;}
            set{canIncrease = value; RaisePropertyChanged("CanIncrease");}}
        public bool CanDecrease{get{return canDecrease;}
            set{canDecrease = value; RaisePropertyChanged("CanDecrease");}}


        //Simply checks out what we have in the text box and makes sure, that the simulation won't start as long, as we don't have
        //appropriate number in there.
        public int ReadBox()
        {   
            //Try parse returns true if parsed text is indeed an integer. We also check if we are bellow the upper boundry.
            if (Int32.TryParse(box_content, out int value) && Int32.Parse(TextBox) <= 20 && Int32.Parse(TextBox) > 0)
            {
                return Int32.Parse(TextBox);
            }
            else
            {
                //Return 0 when conditions are not met. 0 shows us, that wrong value has been inserted, hence we won't move forwartd as long as it stands.
                return 0;
            }
        }

        //Class constructor.
        public MainWindowViewModel()
        {
            BeginSimulationAction = new RelayCommand(() => BeginSimulation());
            //ResumeSimulationAction = new RelayCommand(() => ResumeSimulation());
            //PauseSimulationAction = new RelayCommand(() => PauseSimulation());
            IncreaseSpeedAction = new RelayCommand(() => IncreaseSpeed());
            DecreaseSpeedAction = new RelayCommand(() => DecreaseSpeed());

            //We create new instance of model api and assign it as this object's Model layer representation.
            ModelLayer = ModelAPI.CreateApi();
            Spheres = new ObservableCollection<ISphere>();
            IDisposable observer = ModelLayer.Subscribe<ISphere>(x => Spheres.Add(x));
            for (int i = 0; i < ModelLayer.PresentedSpheres.Count; i++)
            {
                Spheres.Add(ModelLayer.PresentedSpheres[i]);
            }
            //We assign relay commands and tell them which methods shall be activated in case of user interacting with one of the buttons.
        }

        //What happens when user clicks START button.
        private void BeginSimulation()
        {
            //We check out how many balls are required.
            int howMany = ReadBox();
            //The ReadBox method will return 0 if something is wrong with value placed in the box. Only if the value is right can we
            //start the simulation.
            if (howMany != 0)
            {
                //One controller sygnalises that we have started the animation properly.
                IsReadyToBegin = false;
                //Another tells us to start waiting for user to ask us to do something during the animation.
                CanPause = true;
                CanResume = true;
                //Thread for user interaction during the simulation.
                //simulationThread = new Task(Simulation);
                //We assign a method that has a never ending loop to one of the threads. This will simulate sphere movement. 
                //movingThread = new Task(ModelLayer.MoveSpheres);
                //We create required amount of spheres in our model layer.
                ModelLayer.AddNewSpheres(howMany);
                ModelLayer.PickRandomPositions(350, 350);
                //And randomise their positions based on the boundries of the screen and the size of the balls.
                //ModelLayer.PickRandomPositions(ModelLayer.Size[0] - ModelLayer.R * 2, ModelLayer.Size[0] - ModelLayer.R * 2);
                //Now that we have our spheres created we can finally start moving them.
                //movingThread.Start();
                //After we established the model layer all that is left is to update the ViewModel layer (our observable collection needs to be
                //bounded with the list of spheres in ModelAPI).
                //We get rid of current content and refill the collection anew.
                Spheres.Clear();
                for (int i = 0; i < ModelLayer.PresentedSpheres.Count; i++)
                {
                    Spheres.Add(ModelLayer.PresentedSpheres[i]);
                }

                //And we finally begin the simulation.
                ModelLayer.MoveSpheres();
            }
        }

        private void IncreaseSpeed()
        {
            CanIncrease = ModelLayer.ChangeSpeed(true);
            CanDecrease = true;
        }

        private void DecreaseSpeed()
        {
            CanDecrease = ModelLayer.ChangeSpeed(false);
            CanIncrease = true;
        }

        private void ResumeSimulation()
        {
            //Allows the simulation to begin.
            CanPause = true;
            CanResume = false;
            //Assigning new task to a thread.
        }

    }
}
