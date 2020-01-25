/**
 * Ardity (Serial Communication for Arduino + Unity)
 * Author: Daniel Wilches <dwilches@gmail.com>
 *
 * This work is released under the Creative Commons Attributions license.
 * https://creativecommons.org/licenses/by/2.0/
 */

using UnityEngine;
using System.Collections;
using System;
using System.Globalization;
using UnityEngine.UI;
/**
 * When creating your message listeners you need to implement these two methods:
 *  - OnMessageArrived
 *  - OnConnectionEvent
 */
public class SampleMessageListener : MonoBehaviour
{
    public string output;
    public Single[,] Rcal = new Single[3, 3];
    Single[,] Rs = new Single[3, 3];
    Single[,] RT = new Single[3, 3];

    public GameObject cube;

    public Single alfa, beta, gamma;
    public Text Text_output;
    public bool first_time=true;

    //public RotateObject rotar=new RotateObject();

    // Invoked when a line of data is received from the serial device.
    void OnMessageArrived(string msg)
    {
        Debug.Log("Message arrived: " + msg);
        output = msg;
        if (CalculateMatrix(output))
        { // Rs
            if (first_time)
            {
                Calibrar();
                first_time = false;
                Text_output.text = "Sensor Calibrado y listo";
            }
            else
            {
                CalculateEuler();
                //rotar.RotateCube(alfa,beta,gamma); // No me funciona, por qué?

                // Rotation
                cube.transform.rotation = Quaternion.Euler(new Vector3(beta, alfa, gamma));

                // Position
                //int posX = Screen.width/2+Convert.ToInt32(alfa * Screen.width / 40);
                //int posY = Screen.height/2+Convert.ToInt32(beta * Screen.height / 40);

                //cube.transform.position = (new Vector3(posX, posY, 0));

            }

        }
        else
        {
            if (first_time)
            Text_output.text = "Sensor Conectado. Puede pulsar la tecla C para calibrar";
        }

    }

    // Invoked when a connect/disconnect event occurs. The parameter 'success'
    // will be 'true' upon connection, and 'false' upon disconnection or
    // failure to connect.
    void OnConnectionEvent(bool success)
    {
        if (success)
            Debug.Log("Connection established");
        else
            Debug.Log("Connection attempt failed or disconnection detected");
    }

    bool CalculateMatrix (string output)
    {
        
        string [] words = output.Split('=');
        if (words[0] != "#DCM")
        {
            return false; // Not ready, not receiving DCM yet
        }
        else
        {
            // Sensor ready, word[1] contains matrix separated by comas
            string [] words2 = words[1].Split(','); // word2 contains the matrix values
            var clone = (CultureInfo)CultureInfo.InvariantCulture.Clone();
            clone.NumberFormat.NumberDecimalSeparator = ".";
            clone.NumberFormat.NumberGroupSeparator = ".";
            Rs[0, 0] = Convert.ToSingle(decimal.Parse(words2[0], clone));
            Rs[0, 1] = Convert.ToSingle(decimal.Parse(words2[1], clone));
            Rs[0, 2] = Convert.ToSingle(decimal.Parse(words2[2], clone));

            Rs[1, 0] = Convert.ToSingle(decimal.Parse(words2[3], clone));
            Rs[1, 1] = Convert.ToSingle(decimal.Parse(words2[4], clone));
            Rs[1, 2] = Convert.ToSingle(decimal.Parse(words2[5], clone));

            Rs[2, 0] = Convert.ToSingle(decimal.Parse(words2[6], clone));
            Rs[2, 1] = Convert.ToSingle(decimal.Parse(words2[7], clone));
            Rs[2, 2] = Convert.ToSingle(decimal.Parse(words2[8], clone));
            return true;
        }
        

    }

    public void Calibrar()
    {
        Rcal = Rs;
        Rcal = traspuesta(Rcal);
    }

    void CalculateEuler()
    {
        RT = multiplicaMatrices(Rcal, Rs);
        /*
        alfa = Convert.ToSingle(Math.Atan2(-RT[1, 2], RT[2, 2]) * 180 / Math.PI);
        beta = Convert.ToSingle(Math.Asin(RT[0, 2]) * 180 / Math.PI);
        gamma = Convert.ToSingle(Math.Atan2(-RT[0, 1], RT[0, 0]) * 180 / Math.PI);*/
        alfa = Convert.ToSingle(Math.Atan2(RT[1, 2], RT[2, 2]) * 180 / Math.PI);
        beta = Convert.ToSingle(-Math.Asin(RT[0, 2]) * 180 / Math.PI);
        gamma = Convert.ToSingle(Math.Atan2(RT[0, 1], RT[0, 0]) * 180 / Math.PI); 


    }

    private Single[,] multiplicaMatrices(Single[,] matriz1, Single[,] matriz2)
    {

        Single[,] matrizresultante = new Single[3, 3];

        matrizresultante[0, 0] = matriz1[0, 0] * matriz2[0, 0] + matriz1[0, 1] * matriz2[1, 0] + matriz1[0, 2] * matriz2[2, 0];
        matrizresultante[0, 1] = matriz1[0, 0] * matriz2[0, 1] + matriz1[0, 1] * matriz2[1, 1] + matriz1[0, 2] * matriz2[2, 1];
        matrizresultante[0, 2] = matriz1[0, 0] * matriz2[0, 2] + matriz1[0, 1] * matriz2[1, 2] + matriz1[0, 2] * matriz2[2, 2];

        matrizresultante[1, 0] = matriz1[1, 0] * matriz2[0, 0] + matriz1[1, 1] * matriz2[1, 0] + matriz1[1, 2] * matriz2[2, 0];
        matrizresultante[1, 1] = matriz1[1, 0] * matriz2[0, 1] + matriz1[1, 1] * matriz2[1, 1] + matriz1[1, 2] * matriz2[2, 1];
        matrizresultante[1, 2] = matriz1[1, 0] * matriz2[0, 2] + matriz1[1, 1] * matriz2[1, 2] + matriz1[1, 2] * matriz2[2, 2];

        matrizresultante[2, 0] = matriz1[2, 0] * matriz2[0, 0] + matriz1[2, 1] * matriz2[1, 0] + matriz1[2, 2] * matriz2[2, 0];
        matrizresultante[2, 1] = matriz1[2, 0] * matriz2[0, 1] + matriz1[2, 1] * matriz2[1, 1] + matriz1[2, 2] * matriz2[2, 1];
        matrizresultante[2, 2] = matriz1[2, 0] * matriz2[0, 2] + matriz1[2, 1] * matriz2[1, 2] + matriz1[2, 2] * matriz2[2, 2];

        //matrizresultante = normalizaMatriz(matrizresultante);

        return matrizresultante;
    }
    private Single[,] normalizaMatriz(Single[,] matriz)
    {
        Single[,] matrizresultante = new Single[3, 3];

        Single[] fila0 = new Single[3];
        Single[] fila1 = new Single[3];
        Single[] fila2 = new Single[3];

        Single modulo0;
        Single modulo1;
        Single modulo2;


        fila0[0] = matriz[0, 0];
        fila0[1] = matriz[0, 1];
        fila0[2] = matriz[0, 2];
        fila1[0] = matriz[1, 0];
        fila1[1] = matriz[1, 1];
        fila1[2] = matriz[1, 2];
        fila2[0] = matriz[2, 0];
        fila2[1] = matriz[2, 1];
        fila2[2] = matriz[2, 2];

        modulo0 = modulo(fila0);
        modulo1 = modulo(fila1);
        modulo2 = modulo(fila2);


        matrizresultante[0, 0] = matriz[0, 0] / modulo0;
        matrizresultante[0, 1] = matriz[0, 1] / modulo0;
        matrizresultante[0, 2] = matriz[0, 2] / modulo0;

        matrizresultante[1, 0] = matriz[1, 0] / modulo1;
        matrizresultante[1, 1] = matriz[1, 1] / modulo1;
        matrizresultante[1, 2] = matriz[1, 2] / modulo1;

        matrizresultante[2, 0] = matriz[2, 0] / modulo2;
        matrizresultante[2, 1] = matriz[2, 1] / modulo2;
        matrizresultante[2, 2] = matriz[2, 2] / modulo2;

        return matrizresultante;
    }

    private Single[,] traspuesta(Single[,] matriz)
    {
        Single[,] matrizresultante = new Single[3, 3];

        matrizresultante[0, 0] = matriz[0, 0];
        matrizresultante[0, 1] = matriz[1, 0];
        matrizresultante[0, 2] = matriz[2, 0];

        matrizresultante[1, 0] = matriz[0, 1];
        matrizresultante[1, 1] = matriz[1, 1];
        matrizresultante[1, 2] = matriz[2, 1];

        matrizresultante[2, 0] = matriz[0, 2];
        matrizresultante[2, 1] = matriz[1, 2];
        matrizresultante[2, 2] = matriz[2, 2];

        return matrizresultante;
    }

    private Single modulo(Single[] vector)
    {

        Single modulo;

        modulo = 0;
        //  modulo =Math.Sqrt((vector[0]* vector[0]) + (vector[1]* vector[1]) + (vector[2]* vector[2]));

        return modulo;
    }



}
