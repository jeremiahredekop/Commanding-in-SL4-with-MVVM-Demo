using System;
using System.Collections.Generic;
using System.Data.Services.Client;
using System.Linq;
using CommandingWithMvvm.StackOverflow;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace CommandingWithMvvm.ViewModels
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm/getstarted
    /// </para>
    /// </summary>
    public class ODataViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the ODataViewModel class.
        /// </summary>
        public ODataViewModel()
        {
            if (IsInDesignMode)
            {
                // Create design time data objects
                Posts = new List<Post>() { new Post() 
                {
                     Title = "Test Title",
                      Body = "Test Body",
                       Score = 30,
                } };

                SearchText = "Search Text";

            }
            else
            {

                CreateCommand();

            }
        }


        private void CreateCommand()
        {
            // what to do when the fetch is complete
            Action<List<Post>> fetchCompleteAction = pl =>
            {
                //set posts to result
                Posts = pl;
                // tell viewmodel that we are no longer busy
                Busy = false;
            };

            Action<string> fetch = o =>
            {
                // call fetch method (ASYNC with callback)
                fetchData(o, fetchCompleteAction);
                // set busy = true
                Busy = true;
            };

            // create a predicate for when the Command can be executed
            Predicate<string> fetchPredicate = o => String.IsNullOrWhiteSpace(o) == false && o.Length > 3;


            // Create Fetch Command
            FetchCommand = new RelayCommand<string>(fetch, fetchPredicate);
        }

        #region Data Calls

        private void fetchData(string filter, Action<List<Post>> callback)
        {


            StackOverflow.StackOverflow context = new StackOverflow.StackOverflow(new System.Uri("https://odata.sqlazurelabs.com/OData.svc/v0.1/rp1uiewita/StackOverflow"));

            var query = from t in context.Posts
                        where t.Tags.Contains("Silverlight") && t.Score > 5
                        select t;



            if (!String.IsNullOrWhiteSpace(filter))
                query = query.Where(t => t.Body.Contains(filter) || t.Title.Contains(filter));

            DataServiceCollection<Post> posts = new DataServiceCollection<Post>();
            posts.LoadCompleted += (s, e) =>
            {
                if (e.Error != null)
                    throw e.Error;

                callback(posts.ToList());
            };
            posts.LoadAsync(query.OrderByDescending(t => t.CreationDate).Take(30));
        }
        #endregion

        #region Properties


        #region SearchText Property

        /// <summary>
        /// The <see cref="SearchText" /> property's name.
        /// </summary>
        public const string SearchTextPropertyName = "SearchText";

        private string _searchText = "";

        public string SearchText
        {
            get
            {
                return _searchText;
            }

            set
            {
                if (_searchText == value)
                {
                    return;
                }

                var oldValue = _searchText;
                _searchText = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(SearchTextPropertyName);


            }
        }

        #endregion



        #region Busy Property

        /// <summary>
        /// The <see cref="Busy" /> property's name.
        /// </summary>
        public const string BusyPropertyName = "Busy";

        private bool _busy = false;

        /// <summary>
        /// Gets the Busy property.
        /// TODO Update documentation:
        /// Changes to that property's value raise the PropertyChanged event. 
        /// This property's value is broadcasted by the Messenger's default instance when it changes.
        /// </summary>
        public bool Busy
        {
            get
            {
                return _busy;
            }

            set
            {
                if (_busy == value)
                {
                    return;
                }

                var oldValue = _busy;
                _busy = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(BusyPropertyName);

            }
        }

        #endregion


        #region Posts Property

        /// <summary>
        /// The <see cref="Posts" /> property's name.
        /// </summary>
        public const string PostsPropertyName = "Posts";

        private List<Post> _posts = null;

        /// <summary>
        /// Gets the Posts property.
        /// TODO Update documentation:
        /// Changes to that property's value raise the PropertyChanged event. 
        /// This property's value is broadcasted by the Messenger's default instance when it changes.
        /// </summary>
        public List<Post> Posts
        {
            get
            {
                return _posts;
            }

            set
            {
                if (_posts == value)
                {
                    return;
                }

                var oldValue = _posts;
                _posts = value;


                // Update bindings, no broadcast
                RaisePropertyChanged(PostsPropertyName);

            }
        }

        #endregion


        public RelayCommand<string> FetchCommand { get; private set; }


        ////public override void Cleanup()
        ////{
        ////    // Clean own resources if needed

        ////    base.Cleanup();
        ////}

        #endregion
    }
}