/*
MIT License

Copyright (c) 2020 gpsnmeajp

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/

using System;
using System.IO;
using System.Net;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleFileBrowser;
using EasyDeviceDiscoveryProtocolClient;

public class ManagerScript : MonoBehaviour
{
    public InputField pathText;
    public InputField ipText;
    public Text autoDetectedDeviceNameText;
    public InputField pinText;
    public Text statusText;

    public Button fileSelectButton;
    public Button autoDetectButton;
    public Button sendButton;

    public Requester requester;
    public SEDSS_Client client;

    void Start()
    {
        fileSelectButton.onClick.AddListener(() => {
            FileBrowser.SetFilters(true, new FileBrowser.Filter("VRM", ".vrm"));
            FileBrowser.SetDefaultFilter(".vrm");
            StartCoroutine(ShowLoadDialogCoroutineForVRM());
        });

        autoDetectButton.onClick.AddListener(() => {
            ipText.text = "";
            autoDetectedDeviceNameText.text = "";

            requester.StartDiscover(() => {
                ipText.text = requester.responseIpAddress;
                autoDetectedDeviceNameText.text = requester.responseDeviceName;
            });
        });

        sendButton.onClick.AddListener(() => {
            client.SetAddress(ipText.text);
            client.SetPassword(pinText.text);

            if (File.Exists(pathText.text))
            {
                byte[] data = File.ReadAllBytes(pathText.text);
                client.Upload(data, "", (id) =>
                {
                    statusText.text = "【OK】アップロード成功";
                }, (e, id) =>
                {
                    if (e.Contains("Cannot connect"))
                    {
                        statusText.text = "【ERROR】通信相手が見つかりませんでした (うまくいかないときは受信アプリを再起動してみてください)";
                    }
                    else if (e.Contains("400"))
                    {
                        statusText.text = "【ERROR】PINが間違っています (うまくいかないときは受信アプリを再起動してみてください)";
                    }
                    else if (e.Contains("Invalid URI"))
                    {
                        statusText.text = "【ERROR】IPアドレスが変です";
                    }
                    else
                    {
                        statusText.text = "【ERROR】不明なエラー ("+e+")";
                    }
                });
            }
            else {
                statusText.text = "【ERROR】ファイルが見つかりません";
            }
        });
    }

    void Update()
    {
        
    }

    IEnumerator ShowLoadDialogCoroutineForVRM()
    {
        yield return FileBrowser.WaitForLoadDialog(false, true, null, "VRM File", "Select");
        Debug.Log(FileBrowser.Success);
        if (FileBrowser.Success)
        {
            pathText.text = FileBrowser.Result[0];
        }
    }
}
