
var myChart = null;
//counter = 0;
//counterDraw = 0;


function destroyChart() {
    /*
    const ctx = document.getElementById('myChart').getContext('2d');
    myChart = ctx.destroyChart();
    //myChart.destroy();
    */

    /*
    $('#myChart').remove(); // this is my <canvas> element
    $('#graph-container').append('<canvas id="myChart" width="400" height="400"></canvas>');
    */

    var canvas = document.getElementById("myChart");
    canvas.remove();
    var canvas_container = document.getElementById("graph-container");
    var newCanvas = document.createElement("canvas");
    newCanvas.setAttribute("id", "myChart");
    canvas_container.append(newCanvas);

}


function drawChart(dates, cumulativeValues) {


    /*
    if (myChart != null) {
        myChart.destroy();
    }
    */

    if (myChart != null) {
        myChart.destroy();
    }

    const ctx = document.getElementById('myChart').getContext('2d');

    myChart = new Chart(ctx, {
        type: 'line',
        data: {
            labels: dates,
            datasets: [{
                label: 'Planed Total Value',
                data: cumulativeValues,
                borderColor: "#3e95cd",
            } /*,
               
                {
                label: 'Checked Value',
                data: checkedValues,
                borderColor: "#8e5ea2",
                fill: {
                    target: 'origin',

                    below: 'rgb(0, 0, 255)'    // And blue below the origin
                }
            
            }*/
            ]
        },
        options: {
            scales: {
                y: {
                    beginAtZero: true

                }
            },
            animation: {
                duration: 0
            }
        }
    });   /*
    if (checkedValues == null) {
        myChart.data.datasets.splice(0, 1);
        myChart.update();
    }
    */

    //alert("draw counter " + counterDraw++);
    checkeadded = false;
}

function addCheckedValues(checkedValues) {

    if (!checkeadded) { // for some reason InvokeVoidAsync in OnAfterRenderAsync method in EditGoal.rasor is called twice, each row separately is called twice!
        myChart.data.datasets.push({
            label: 'Checked Total Value',
            borderColor: "#8e5ea2",
            data: checkedValues,
            fill: {
                target: 'origin',

                below: 'rgb(0, 0, 255)'
            }// And blue below the origin
        });
        myChart.update();
        //alert(counter++);
        checkeadded = true;
    }
}

// Use it for .NET 6+
function BlazorDownloadFile(filename, contentType, content) {
    // Create the URL
    const file = new File([content], filename, { type: contentType });
    const exportUrl = URL.createObjectURL(file);

    // Create the <a> element and click on it
    const a = document.createElement("a");
    document.body.appendChild(a);
    a.href = exportUrl;
    a.download = filename;
    a.target = "_self";
    a.click();

    // We don't need to keep the object url, let's release the memory
    // On Safari it seems you need to comment this line... (please let me know if you know why)
    URL.revokeObjectURL(exportUrl);
}