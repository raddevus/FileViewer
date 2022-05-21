

function initFiles(){
  // Registers the receive loop for the program
  window.external.receiveMessage(response => {
      alert(response);
      response = JSON.parse(response);
      alert(response.command);
      switch (response.command){
          case "getInitialPath":{
              document.querySelector("#clearTextFilePath").value = response.data;
              break;
          }
          default:{
              alert(response.data)
              break;
          }
      }
    });



    ReactDOM.render(
        React.createElement('h1', null, 'Hello world!'),
        document.getElementById('files')
      );
      
      // window.external.receiveClearTextPath(currentDir => {
      //   document.querySelector("#clearTextFilePath").text = currentDir;
      // });

      let currentDir = window.external.sendMessage("getInitialPath");
}
