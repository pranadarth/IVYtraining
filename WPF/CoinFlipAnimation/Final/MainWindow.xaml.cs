using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Final
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Model3DGroup MainModel3Dgroup = new Model3DGroup();
        public MainWindow()
        {
            InitializeComponent();
            cylinder();
            // AddCircleModel();
        }



        private void cylinder()
        {


            // Add the group of models to a ModelVisual3D.
            ModelVisual3D model_visual = new ModelVisual3D();
            model_visual.Content = MainModel3Dgroup;

            MeshGeometry3D mesh2 = new MeshGeometry3D();
            AddCylinder(mesh2, new Point3D(0, 0, 0.05),
                new Vector3D(0, 0, -0.0501), .4, 100);
            MaterialGroup mg1 = new MaterialGroup();
            MaterialGroup mg2 = new MaterialGroup();
            // SolidColorBrush brush2 = Brushes.DarkBlue;
            ImageBrush brush2 = new ImageBrush();
            brush2.ImageSource = new BitmapImage(new Uri(@"C:\Users\suresh.pranadarth\source\repos\IVYtraining\WPF\CoinFlipAnimation\CoinFlipAnimation\chatbot.png", UriKind.Relative));
            DiffuseMaterial material2 = new DiffuseMaterial();
            material2.Brush = new SolidColorBrush(Colors.White);
            SolidColorBrush brush1 = new SolidColorBrush(Color.FromRgb(237, 110, 19));
            DiffuseMaterial material1 = new DiffuseMaterial();
            material1.Brush = brush2;
            mg1.Children.Add(material1);
            mg2.Children.Add(material2);
            GeometryModel3D model2 = new GeometryModel3D();
            model2.Geometry = mesh2;
            model2.Material = mg2;
            model2.BackMaterial = mg1;
            MainModel3Dgroup.Children.Add(model2);

            MeshGeometry3D mesh = new MeshGeometry3D();
            AddCylinder(mesh, new Point3D(0, 0, 0.1001),
                new Vector3D(0, 0, -0.05), .4, 100);

            // SolidColorBrush brush2 = Brushes.DarkBlue;
            DiffuseMaterial material = new DiffuseMaterial();
            material.Brush = new SolidColorBrush(Color.FromRgb(237, 110, 19));
            GeometryModel3D model = new GeometryModel3D(mesh, material);
            MainModel3Dgroup.Children.Add(model);

            MeshGeometry3D mesh3 = new MeshGeometry3D();
            AddCylinder(mesh3, new Point3D(0, 0, 0.1),
                new Vector3D(0, 0, -0.1), .4, 100);

            // SolidColorBrush brush2 = Brushes.DarkBlue;
            DiffuseMaterial material3 = new DiffuseMaterial();
            material3.Brush = new SolidColorBrush(Color.FromRgb(237, 110, 19));
            GeometryModel3D model3 = new GeometryModel3D(mesh3, material3);

            MainModel3Dgroup.Children.Add(model3);


            // Display the main visual to the viewportt.
            mainViewPort.Children.Add(model_visual);

        }


        private void AddCylinder(MeshGeometry3D mesh,
    Point3D end_point, Vector3D axis, double radius, int num_sides)
        {
            // Get two vectors perpendicular to the axis.
            Vector3D v1;
            if ((axis.Z < -0.01) || (axis.Z > 0.01))
                v1 = new Vector3D(axis.Z, axis.Z, -axis.X - axis.Y);
            else
                v1 = new Vector3D(-axis.Y - axis.Z, axis.X, axis.X);
            Vector3D v2 = Vector3D.CrossProduct(v1, axis);

            // Make the vectors have length radius.
            v1 *= (radius / v1.Length);
            v2 *= (radius / v2.Length);

            // Make the top end cap.
            double theta = 0;
            double dtheta = 2 * Math.PI / num_sides;
            for (int i = 0; i < num_sides; i++)
            {
                Point3D p1 = end_point +
                    Math.Cos(theta) * v1 +
                    Math.Sin(theta) * v2;
                theta += dtheta;
                Point3D p2 = end_point +
                    Math.Cos(theta) * v1 +
                    Math.Sin(theta) * v2;
                AddTriangle(mesh, end_point, p1, p2);
            }

            // Make the bottom end cap.
            Point3D end_point2 = end_point + axis;
            theta = 0;
            for (int i = 0; i < num_sides; i++)
            {
                Point3D p1 = end_point2 +
                    Math.Cos(theta) * v1 +
                    Math.Sin(theta) * v2;
                theta += dtheta;
                Point3D p2 = end_point2 +
                    Math.Cos(theta) * v1 +
                    Math.Sin(theta) * v2;
                AddTriangle(mesh, end_point2, p2, p1);
            }

            // Make the sides.
            theta = 0;
            for (int i = 0; i < num_sides; i++)
            {
                Point3D p1 = end_point +
                    Math.Cos(theta) * v1 +
                    Math.Sin(theta) * v2;
                theta += dtheta;
                Point3D p2 = end_point +
                    Math.Cos(theta) * v1 +
                    Math.Sin(theta) * v2;

                Point3D p3 = p1 + axis;
                Point3D p4 = p2 + axis;

                AddTriangle(mesh, p1, p3, p2);
                AddTriangle(mesh, p2, p3, p4);
            }
        }



        private void AddTriangle(MeshGeometry3D mesh, Point3D point1, Point3D point2, Point3D point3)
        {
            // Create the points.
            int index1 = mesh.Positions.Count;
            mesh.Positions.Add(point1);
            mesh.Positions.Add(point2);
            mesh.Positions.Add(point3);

            // Create the triangle.
            mesh.TriangleIndices.Add(index1++);
            mesh.TriangleIndices.Add(index1++);
            mesh.TriangleIndices.Add(index1);
        }

        

      

    }

}

