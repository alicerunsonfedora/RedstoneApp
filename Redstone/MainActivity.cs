using System;
using Android.App;
using Android.Widget;
using Android.OS;

namespace Redstone
{
    [Activity(MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            int count = 0;

            //Initialize all of the blocks that will be used in the map generation.
            var redstoneBlocks = new RedstoneCore();
            var commBlock = new CommandBlock();
            var redRepeater = new RedstoneRepeater();
            var redLamp = new RedstoneLamp();
            var redComparator = new RedstoneComparator();
            var quaBlock = new QuartzBlock();
            var normPiston = new Piston();

            //Create a button variable and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.myButton);
            Button defaultButton = FindViewById<Button>(Resource.Id.defaultButton);

            TextView randomGenText = FindViewById<TextView>(Resource.Id.randomGenText);


            //Create the map matrix.
            var Matrix = new MappedMatrix();

            ImageView MatrixCoordinate00 = FindViewById<ImageView>(Resource.Id.imageView1);
            ImageView MatrixCoordinate01 = FindViewById<ImageView>(Resource.Id.imageView2);
            ImageView MatrixCoordinate02 = FindViewById<ImageView>(Resource.Id.imageView3);
            ImageView MatrixCoordinate03 = FindViewById<ImageView>(Resource.Id.imageView4);
            ImageView MatrixCoordinate04 = FindViewById<ImageView>(Resource.Id.imageView5);
            ImageView MatrixCoordinate05 = FindViewById<ImageView>(Resource.Id.imageView6);

            ImageView MatrixCoordinate10 = FindViewById<ImageView>(Resource.Id.imageView7);
            ImageView MatrixCoordinate11 = FindViewById<ImageView>(Resource.Id.imageView8);
            ImageView MatrixCoordinate12 = FindViewById<ImageView>(Resource.Id.imageView9);
            ImageView MatrixCoordinate13 = FindViewById<ImageView>(Resource.Id.imageView10);
            ImageView MatrixCoordinate14 = FindViewById<ImageView>(Resource.Id.imageView11);
            ImageView MatrixCoordinate15 = FindViewById<ImageView>(Resource.Id.imageView12);

            ImageView MatrixCoordinate20 = FindViewById<ImageView>(Resource.Id.imageView13);
            ImageView MatrixCoordinate21 = FindViewById<ImageView>(Resource.Id.imageView14);
            ImageView MatrixCoordinate22 = FindViewById<ImageView>(Resource.Id.imageView15);
            ImageView MatrixCoordinate23 = FindViewById<ImageView>(Resource.Id.imageView16);
            ImageView MatrixCoordinate24 = FindViewById<ImageView>(Resource.Id.imageView17);
            ImageView MatrixCoordinate25 = FindViewById<ImageView>(Resource.Id.imageView18);

            ImageView MatrixCoordinate30 = FindViewById<ImageView>(Resource.Id.imageView19);
            ImageView MatrixCoordinate31 = FindViewById<ImageView>(Resource.Id.imageView20);
            ImageView MatrixCoordinate32 = FindViewById<ImageView>(Resource.Id.imageView21);
            ImageView MatrixCoordinate33 = FindViewById<ImageView>(Resource.Id.imageView22);
            ImageView MatrixCoordinate34 = FindViewById<ImageView>(Resource.Id.imageView23);
            ImageView MatrixCoordinate35 = FindViewById<ImageView>(Resource.Id.imageView24);

            //Create an ImageView matrix to compare to the map matrix.
            ImageView[][] ImageMatrix = new ImageView[4][];
            ImageMatrix[0] = new ImageView[6]{MatrixCoordinate00, MatrixCoordinate01, MatrixCoordinate02, MatrixCoordinate03, MatrixCoordinate04, MatrixCoordinate05};
            ImageMatrix[1] = new ImageView[6] { MatrixCoordinate10, MatrixCoordinate11, MatrixCoordinate12, MatrixCoordinate13, MatrixCoordinate14, MatrixCoordinate15 };
            ImageMatrix[2] = new ImageView[6] { MatrixCoordinate20, MatrixCoordinate21, MatrixCoordinate22, MatrixCoordinate23, MatrixCoordinate24, MatrixCoordinate25 };
            ImageMatrix[3] = new ImageView[6] { MatrixCoordinate30, MatrixCoordinate31, MatrixCoordinate32, MatrixCoordinate33, MatrixCoordinate34, MatrixCoordinate35 };

            //Creates a redstone map.
            void CreateRedstoneMap(string type)
            {
                if (type == "random")
                {
                    Matrix.CreateRandomMatrix();
                }
                else if (type == "default")
                {
                    Matrix.CreateDefaultMatrix();
                }

                //For every element in the ImageView matrix, change the image depending on the integer value in the map's matrix.
                for (int i = 0; i < Matrix.DefaultMatrix.Length; i++)
                {
                    for (int j = 0; j < Matrix.DefaultMatrix[i].Length; j++)
                    {
                        //Conditional logic to determine which texture is loaded in an element

                        //Redstone Ore and Block
                        if (Matrix.DefaultMatrix[i][j] == redstoneBlocks.MappedMatrixInteger)
                        {
                            if (redstoneBlocks.IsToggleable == true)
                            {
                                int randomVariant = Matrix.RandomNumber(0, 2);

                                if (randomVariant == 0)
                                {
                                    ImageMatrix[i][j].SetImageResource(Convert.ToInt32(redstoneBlocks.ToggleableValues[0, 1]));
                                }
                                else if (randomVariant == 1)
                                {
                                    ImageMatrix[i][j].SetImageResource(Convert.ToInt32(redstoneBlocks.ToggleableValues[1, 1]));
                                }
                            }
                            /*else
                            {
                                ImageMatrix[i][j].SetImageResource(redstoneBlocks.MappedMatrixDefaultLocation);
                            }*/

                        }

                        //Command Block
                        else if (Matrix.DefaultMatrix[i][j] == commBlock.MappedMatrixInteger)
                        {
                            if (commBlock.IsToggleable == true)
                            {
                                int randomVariant = Matrix.RandomNumber(0, 2);

                                if (randomVariant == 0)
                                {
                                    ImageMatrix[i][j].SetImageResource(Convert.ToInt32(commBlock.ToggleableValues[0, 1]));
                                }
                                else if (randomVariant == 1)
                                {
                                    ImageMatrix[i][j].SetImageResource(Convert.ToInt32(commBlock.ToggleableValues[1, 1]));
                                }
                            }
                            else
                            {
                                ImageMatrix[i][j].SetImageResource(commBlock.MappedMatrixDefaultLocation);
                            }
                        }

                        //Redstone Repeater (both on and off)
                        else if (Matrix.DefaultMatrix[i][j] == redRepeater.MappedMatrixInteger)
                        {
                            if (redRepeater.IsToggleable == true)
                            {
                                int randomVariant = Matrix.RandomNumber(0, 2);

                                if (randomVariant == 0)
                                {
                                    ImageMatrix[i][j].SetImageResource(Convert.ToInt32(redRepeater.ToggleableValues[0, 1]));
                                }
                                else if (randomVariant == 1)
                                {
                                    ImageMatrix[i][j].SetImageResource(Convert.ToInt32(redRepeater.ToggleableValues[1, 1]));
                                }
                            }
                            else
                            {
                                ImageMatrix[i][j].SetImageResource(redRepeater.MappedMatrixDefaultLocation);
                            }
                        }

                        //Redstone Lamp (both on and off)
                        else if (Matrix.DefaultMatrix[i][j] == redLamp.MappedMatrixInteger)
                        {
                            if (redLamp.IsToggleable == true)
                            {
                                int randomVariant = Matrix.RandomNumber(0, 2);

                                if (randomVariant == 0)
                                {
                                    ImageMatrix[i][j].SetImageResource(Convert.ToInt32(redLamp.ToggleableValues[0, 1]));
                                }
                                else if (randomVariant == 1)
                                {
                                    ImageMatrix[i][j].SetImageResource(Convert.ToInt32(redLamp.ToggleableValues[1, 1]));
                                }
                            }
                            else
                            {
                                ImageMatrix[i][j].SetImageResource(redLamp.MappedMatrixDefaultLocation);
                            }
                        }

                        //Redstone Comparator (both on and off)
                        else if (Matrix.DefaultMatrix[i][j] == redComparator.MappedMatrixInteger)
                        {
                            if (redComparator.IsToggleable == true)
                            {
                                int randomVariant = Matrix.RandomNumber(0, 2);

                                if (randomVariant == 0)
                                {
                                    ImageMatrix[i][j].SetImageResource(Convert.ToInt32(redComparator.ToggleableValues[0, 1]));
                                }
                                else if (randomVariant == 1)
                                {
                                    ImageMatrix[i][j].SetImageResource(Convert.ToInt32(redComparator.ToggleableValues[1, 1]));
                                }
                            }
                            else
                            {
                                ImageMatrix[i][j].SetImageResource(redComparator.MappedMatrixDefaultLocation);
                            }
                        }

                        //Quartz Block
                        else if (Matrix.DefaultMatrix[i][j] == quaBlock.MappedMatrixInteger)
                        {
                            if (quaBlock.IsToggleable == true)
                            {
                                int randomVariant = Matrix.RandomNumber(0, 2);

                                if (randomVariant == 0)
                                {
                                    ImageMatrix[i][j].SetImageResource(Convert.ToInt32(quaBlock.ToggleableValues[0, 1]));
                                }
                                else if (randomVariant == 1)
                                {
                                    ImageMatrix[i][j].SetImageResource(Convert.ToInt32(quaBlock.ToggleableValues[1, 1]));
                                }
                            }
                            else
                            {
                                ImageMatrix[i][j].SetImageResource(quaBlock.MappedMatrixDefaultLocation);
                            }
                        }

                        //Piston (Normal and Sticky)
                        else if (Matrix.DefaultMatrix[i][j] == normPiston.MappedMatrixInteger)
                        {
                            if (normPiston.IsToggleable == true)
                            {
                                int randomVariant = Matrix.RandomNumber(0, 2);

                                if (randomVariant == 0)
                                {
                                    ImageMatrix[i][j].SetImageResource(Convert.ToInt32(normPiston.ToggleableValues[0, 1]));
                                }
                                else if (randomVariant == 1)
                                {
                                    ImageMatrix[i][j].SetImageResource(Convert.ToInt32(normPiston.ToggleableValues[1, 1]));
                                }
                            }
                            else
                            {
                                ImageMatrix[i][j].SetImageResource(normPiston.MappedMatrixDefaultLocation);
                            }
                        }
                    }
                }   
            }

            CreateRedstoneMap("default");

            //Upon clicking the button, randomly generate a map and display how many times the button has been clicked.
            button.Click += delegate 
            {
                count++; //Add to the counter
                CreateRedstoneMap("random");
                Toast.MakeText(this, Resource.String.success_random, ToastLength.Short).Show(); //Create toast to notify user of map generation success

                //Update the random generations text based on count
                if (count == 1)
                {
                    randomGenText.Text = count.ToString() + " random generation";
                } 

                else if (count >= 2)
                {
                    randomGenText.Text = count.ToString() + " random generations";
                }
            };

            defaultButton.Click += delegate 
            {
                CreateRedstoneMap("default");
                Toast.MakeText(this, Resource.String.success_default, ToastLength.Short).Show();//Create toast to notify user of map generation success
            };
        }
    }
}

