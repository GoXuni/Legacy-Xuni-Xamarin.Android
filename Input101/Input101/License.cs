using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Input101
{
    public static class License
    {
        public const string Key =
            "ABgBGAIYB4BJAG4AcAB1AHQAMQAwADEAZj0pAG2XLZyGwHcVv5Z1C6Vti0AwBMee" +
            "QcCjQkJRCKHo5E52EWmo068bBpJx6ZadUmZCAmuFiERSSUOG+zR/D36g1tJAGp4E" +
            "jFzA34po9zc6K+MfRYV8VDsDidxfig+ynHWRX0z4I2VD73onsLSpeyvyWdVkAhSH" +
            "lk8/eiCelfWe4Y4CGjiwhwFvmfG/ZxZOVtwefe++7orLnF5flmu76R4u+u3ee37K" +
            "oWau/umOjIImsnz4q+f99RRW4Tyly0IBGxR5XUUPLs0vn0J8p7PgcqHgkDIz8NaY" +
            "N17MwWp+NKsQUf+C3w0iNDiKhvV8sE6NexTP1ksjp6DW9IsKrFAkpKudw94LlaQ7" +
            "AEz/0BSgzdIYKS3fuOQp+iCcm/bWELnXmeykD2urF7tdczLQ0FhVvgOekB6qkOW4" +
            "iYV8IJzyW7apSa6LqGqqU2x9lyq1PhLZTXVZlp9mbjyBhaZPlsv3wmQW2L5PVcKS" +
            "1sIfiZ2nK6ShN9lPZz2GEx5vHhopvGSOMHNJnz5IJGFJZY5b4D2/iJyyVXibU0hx" +
            "aSa1bpS4sovkCq+wLmF5zDVuZmVW7ARhkG2GrJprkw/Cj/HhXCFgb+xoMWk1VcWn" +
            "TwWoH85IR8X1mHso+SojEe8gY2WQb/CYMwEfbHgRxRdOWof2H94ol95xHiAXtCrI" +
            "pp+9AHbjBEgwggVkMIIETKADAgECAhAiELIXSwsSf7soBS4RsyUKMA0GCSqGSIb3" +
            "DQEBBQUAMIG0MQswCQYDVQQGEwJVUzEXMBUGA1UEChMOVmVyaVNpZ24sIEluYy4x" +
            "HzAdBgNVBAsTFlZlcmlTaWduIFRydXN0IE5ldHdvcmsxOzA5BgNVBAsTMlRlcm1z" +
            "IG9mIHVzZSBhdCBodHRwczovL3d3dy52ZXJpc2lnbi5jb20vcnBhIChjKTEwMS4w" +
            "LAYDVQQDEyVWZXJpU2lnbiBDbGFzcyAzIENvZGUgU2lnbmluZyAyMDEwIENBMB4X" +
            "DTEzMDkyNDAwMDAwMFoXDTE2MTAyMzIzNTk1OVowgacxCzAJBgNVBAYTAlVTMRUw" +
            "EwYDVQQIEwxQZW5uc3lsdmFuaWExEzARBgNVBAcTClBpdHRzYnVyZ2gxFTATBgNV" +
            "BAoUDENvbXBvbmVudE9uZTE+MDwGA1UECxM1RGlnaXRhbCBJRCBDbGFzcyAzIC0g" +
            "TWljcm9zb2Z0IFNvZnR3YXJlIFZhbGlkYXRpb24gdjIxFTATBgNVBAMUDENvbXBv" +
            "bmVudE9uZTCCASIwDQYJKoZIhvcNAQEBBQADggEPADCCAQoCggEBALnLoJqpSVVq" +
            "nJLza05lTIcakcvyl7dxBxZ+cwk4Cqk6+UaC6f5Z5LvRD1+AhiARulIgI7vPgkCf" +
            "+c83iOViQWyJuXFJMnGava3AZ6X/o0DaUqzYzFOWz/MrAzOJvYMtrj/NT9m8BWei" +
            "+UkY1NWUytiSa0JINYt55i/FztxXtP7K27Lj3ZYwwUkNLOKJ4f+qkR0QSnygYUQQ" +
            "yMDOLg5vfYkDLdUQkNretBT2JZ6x6dkNcCpif5dbZ01MOFEEjZJlGdnvrenuOYfw" +
            "5CNloDSCRzttSJ89JtJOjQxyrBQf1ylOXoiXCPpzAXCU2SF/dYXSimVM8pT0NZ7p" +
            "UNG1H+Az2nMCAwEAAaOCAXswggF3MAkGA1UdEwQCMAAwDgYDVR0PAQH/BAQDAgeA" +
            "MEAGA1UdHwQ5MDcwNaAzoDGGL2h0dHA6Ly9jc2MzLTIwMTAtY3JsLnZlcmlzaWdu" +
            "LmNvbS9DU0MzLTIwMTAuY3JsMEQGA1UdIAQ9MDswOQYLYIZIAYb4RQEHFwMwKjAo" +
            "BggrBgEFBQcCARYcaHR0cHM6Ly93d3cudmVyaXNpZ24uY29tL3JwYTATBgNVHSUE" +
            "DDAKBggrBgEFBQcDAzBxBggrBgEFBQcBAQRlMGMwJAYIKwYBBQUHMAGGGGh0dHA6" +
            "Ly9vY3NwLnZlcmlzaWduLmNvbTA7BggrBgEFBQcwAoYvaHR0cDovL2NzYzMtMjAx" +
            "MC1haWEudmVyaXNpZ24uY29tL0NTQzMtMjAxMC5jZXIwHwYDVR0jBBgwFoAUz5mp" +
            "6nsm9EvJjo/X8AUm7+PSp50wEQYJYIZIAYb4QgEBBAQDAgQQMBYGCisGAQQBgjcC" +
            "ARsECDAGAQEAAQH/MA0GCSqGSIb3DQEBBQUAA4IBAQBhzVY5zjwYAFjmIa2JSWbq" +
            "eXQ1jrf2o5DoRYWgI/+4LEpJ+U2o+VAI5kIYSNGp5Yjq7XvQosjs/C6qdwpfTd3b" +
            "h2lEER4XCRzpo+4HK9Wxwj0D8P1UoUn43LjlbMB/GzRRhNq0BN+ETlD0+BejspoU" +
            "ssd5GRhGLNOXmtDV+9/a7j7h9t5JEMk++JblysVe6UpcgtoY9XguZLsm5DOhQT0Q" +
            "IlgOIK1QSl/whiKGdPBfD5jN4/SHsGVUbPpC+Pxjh5yT/LSm9+Nqk+tzMQQcpbTf" +
            "eLKs9kLgsG4Uo9fsg5wOl4FN4CBHo2CLXEqtriy3//rpUMOutVKmm1awHhgGqsuF" +
            "MIICuDCCAaCgAwIBAgIIc5jdAjnXnu8wDQYJKoZIhvcNAQEFBQAwHDEaMBgGA1UE" +
            "AwwRR0MtU1UxMTUwMC02NjY2NjYwHhcNMTUwMTAxMDAwMDAwWhcNMjAwNDMwMDAw" +
            "MDAwWjAcMRowGAYDVQQDDBFHQy1TVTExNTAwLTY2NjY2NjCCASIwDQYJKoZIhvcN" +
            "AQEBBQADggEPADCCAQoCggEBAIrEk5yHEc5zsMI0rXO2Q48TO0Y5x+KxiBCmjhdP" +
            "iQNeNWL/N5R5UxWRmI6uG52oE0B/QXG5avm2X6G0oQLinSX9alx22Oe3eicPA0AU" +
            "TaZJAB3Az0dpsYnzmh/gyUS19y+Wwut6O6QUCoxgalAUNnJ2f0kJr6Jj2SgbQSsh" +
            "uPno/390pn+P3wg83zYlTfdAigPp3qjzv92h9HLr/bTPsOYFqc1Dn6wmVWi/8lkP" +
            "4HjXrPpcbcaCobbvsLcod7hFkw3YAeqqhgdpl/wmRy3wT2t4xJmGj4q4iMyY1OIl" +
            "F5kB9RnrsYMkETS2jMWflNaaq9PXrT14qPTtczjP68maA3UCAwEAATANBgkqhkiG" +
            "9w0BAQUFAAOCAQEAH/R2Rs/rb09MK+KdhXZUyQbFFCntw7Z27ZwhDPx8Z4aS7a7C" +
            "B1Z2PHNLc2U9oAgAzyXwQGX0GVF3ixpn4kfRBxcP6JfDQ0cdLodDdSwHQeNo2+GO" +
            "cOnpKhsctD2z+WTXs39BB21ZDbEK5tQMtmPAX7pxENyQY7m4ZouTN59Y9111yE5H" +
            "VFJwO+P1Ys9cdTasEpJxVmYF4It5ZVhfNnA3mchCmcVBS6URtWhsUIaY55kdmXSM" +
            "Yd5NmRGs3HNG/2IzfLz9GGc1kFtUf/j6ZlIpYefPLhP9k8/ij62HwNl5W7fqm1D3" +
            "pDx6eju2XoQNeBu4Ux0EwVdlAVAMvwUN6uUf5A==";
    }

}