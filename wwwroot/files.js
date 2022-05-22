

function initFiles(){
  // Registers the receive loop for the program
  window.external.receiveMessage(response => {
      //alert(response);
      response = JSON.parse(response);
      //alert(response.command);
      switch (response.command){
          case "getInitialPath":{
              document.querySelector("#clearTextFilePath").value = response.data;
              //alert(`${response.fsi[0].Name} | ${response.fsi[0].Type} | ${response.fsi[0].FullName}`);
              DisplayFileSystemTable(response.fsi, "#fileSystemItems");
              break;
          }
          default:{
              alert(response.data)
              break;
          }
      }
    });

    ReactDOM.createRoot(document.querySelector('#files'))
        .render(
        React.createElement('h3', null, 'File System'),
        
      );
      
      // window.external.receiveClearTextPath(currentDir => {
      //   document.querySelector("#clearTextFilePath").text = currentDir;
      // });

      let currentDir = window.external.sendMessage("getInitialPath");
}

function FileSystemTable(fileSystemInfo){

  console.log(fileSystemInfo[0]);
   let allItems = [];

  for (let x=0; x < fileSystemInfo.length;x++){
      allItems.push( React.createElement("tr",{key:x},
          React.createElement("td",{width:"150px"}, fileSystemInfo[x].Name),
          React.createElement("td",null, fileSystemInfo[x].Type),
          React.createElement("td",null, fileSystemInfo[x].FullName)
          )
     );
  }
  return allItems;
}

function DisplayFileSystemTable(fsi, rootElement){
  ReactDOM.createRoot(document
    .querySelector(rootElement))
    .render(
      FileSystemTable (fsi),
      //hideWaitCursor();
  );
}

