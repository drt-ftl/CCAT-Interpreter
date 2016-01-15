using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using UnityEngine;

namespace CCAT_Interpreter_Form
{
    public partial class Form1 : Form
    {
        public static string filename = "";
        public static List<CcatDataPoint> points = new List<CcatDataPoint>();
        public float StartTime = 0;
        public float stepsize = 0;
        public float runningDistance = 0;
        private Vector3 MinVector = Vector3.one * 1000000;
        private Vector3 MaxVector = Vector3.one * -1000000;
        private Vector3 Centroid = Vector3.zero;

        public Form1()
        {
            InitializeComponent();
        }

        private void OpenButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            if (!openFileDialog1.FileName.EndsWith(".csv")) return;
            filename = openFileDialog1.FileName;
            var tr = File.OpenText(filename);
            bool afterFirst = false;
            while (!tr.EndOfStream)
            {
                var textLine = tr.ReadLine();
                var split = textLine.Split(',');
                if (afterFirst)
                {
                    float t;
                    float x;
                    float y;
                    float z;
                    if (float.TryParse(split[0], out t))
                    {
                        var v = Vector3.zero;
                        t /= 1000; // Scale To Seconds (from ms)
                        if (float.TryParse(split[157], out x) && float.TryParse(split[158], out z) && float.TryParse(split[147], out y))
                        {
                            v.x = x;
                            v.y = y;
                            v.z = -z;
                            v /= 101600f; // Scale to inches (from turns)
                            var newPoint = new CcatDataPoint();
                            newPoint.Position = v;
                            if (points.Count == 0)
                            {
                                StartTime = t; // Set start time
                            }
                            t -= StartTime; // set so start is 0
                            newPoint.EventTime = t;
                            points.Add(newPoint);
                            if (points.Count > 1163)
                            {
                                var index = points.Count - 1;
                                runningDistance += Vector3.Distance(points[index].Position, points[index - 1].Position);
                            }
                            if (v.x < MinVector.x)
                                MinVector.x = v.x;
                            if (v.x > MaxVector.x)
                                MaxVector.x = v.x;
                            if (v.y < MinVector.y)
                                MinVector.y = v.y;
                            if (v.y > MaxVector.y)
                                MaxVector.y = v.y;
                            if (v.z < MinVector.z)
                                MinVector.z = v.z;
                            if (v.z > MaxVector.z)
                                MaxVector.z = v.z;
                        }
                    }

                }
                afterFirst = true;
            }
            tr.Close();
            Centroid = (MaxVector + MinVector) / 2.0f;
            stepsize = runningDistance / (points.Count - 1163);
            var smallStr = "";
            smallStr += points.Count.ToString() + " Points.\r\n";
            UpperReadoutLabel.Text = smallStr;
        }
        private void UpDown_PointsPerSample_ValueChanged(object sender, EventArgs e)
        {

        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        void SaveData()
        {
            var saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            saveFileDialog.InitialDirectory = "C://";
            var sel = "CCAT Files (*.cct)|*.cct";
            saveFileDialog.Filter = sel;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.InitialDirectory = "C:\\Users\\David\\Documents\\GitHub\\VAME\\Assets\\Samples";
            if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                stepsize *= (float)UpDown_PointsPerSample.Value;
                var numPointsToSave = Mathf.FloorToInt((points.Count - 1163) / (float)UpDown_PointsPerSample.Value);
                var distance = 1f;
                var tw = File.CreateText(saveFileDialog.FileName);
                tw.WriteLine("X,Y.Z,Temp");
                tw.WriteLine("STEPSIZE:" + stepsize.ToString("f4"));
                tw.WriteLine("DISTANCE:" + distance.ToString("f4"));
                tw.WriteLine("POINTS:" + numPointsToSave.ToString());
                for (int i = 1163; i <= points.Count; i += (int)UpDown_PointsPerSample.Value)
                {
                    if (i < points.Count)
                    {
                        var point = points[i];
                        var p = point.Position - Centroid;
                        tw.WriteLine(p.x.ToString("f4") + "," + p.y.ToString("f4") + "," + p.z.ToString("f4") + ", 3000");
                    }
                }
                tw.Close();
            }
        }
    }
}
