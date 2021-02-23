const getWeather = function() {
    
    const zipcode = $("#zip").val()

    $.get(

        `http://api.openweathermap.org/data/2.5/weather?units=imperial&zip=${zipcode},US&appid=18ddbf78e41187927d55c318beaeef48`,
        function(data, textStatus, jqXHR){
            
            $("#reportHeader").text(`Weather Report for ${data.name}`);
            $("#weatherDesc").text(data.weather[0].description);

            let imageurl = `http://openweathermap.org/img/wn/${data.weather[0].icon}@2x.png`;

            $("#weatherIcon").attr("src", imageurl);
            $("#currentSpan").text(`${data.main.temp}`);
            
            console.log(data);
            console.log(textStatus);
            console.log(jqXHR);
        }

    );
}