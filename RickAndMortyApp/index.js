let getResultsFilter = function() {

    const charName = $("#characterNameInput").val();
    const statusSelect = $("#statusSelect").val();

    $.get(
        `https://rickandmortyapi.com/api/character/?name=${charName}&status=${statusSelect}`,
        function(data, textStatus, jqXHR){
            
            let randomNum = Math.floor(Math.random() * data.results.length);                
            $("#characterImage").attr("src", data.results[randomNum].image);
            
            $("#characterName").text(`Name: ${data.results[randomNum].name}`);
            $("#characterStatus").text(`Status: ${data.results[randomNum].status}`);
            $("#characterSpecies").text(`Species: ${data.results[randomNum].species}`);
            $("#characterGender").text(`Gender: ${data.results[randomNum].gender}`);
            $("#characterOrigin").text(`Origin: ${data.results[randomNum].origin.name}`);
            $("#characterLocation").text(`Location: ${data.results[randomNum].location.name}`);

        }

    );

}

let getGenderCharacters = function() {

    const charGender = $("#genderSelect").val();

    $.get(
        `https://rickandmortyapi.com/api/character/?gender=${charGender}`,
        function(data, textStatus, jqXHR){
            
                let randomNum = Math.floor(Math.random() * data.results.length);                
                $("#characterImage").attr("src", data.results[randomNum].image);

                $("#characterName").text(`Name: ${data.results[randomNum].name}`);
                $("#characterStatus").text(`Status: ${data.results[randomNum].status}`);
                $("#characterSpecies").text(`Species: ${data.results[randomNum].species}`);
                $("#characterGender").text(`Gender: ${data.results[randomNum].gender}`);
                $("#characterOrigin").text(`Origin: ${data.results[randomNum].origin.name}`);
                $("#characterLocation").text(`Location: ${data.results[randomNum].location.name}`);

        }

    );

}