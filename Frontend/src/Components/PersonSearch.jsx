import React, { useState } from "react";
import Grid from '@mui/material/Unstable_Grid2';
import TextField from '@mui/material/TextField';
import Button from '@mui/material/Button';
import SearchIcon from '@mui/icons-material/Search';
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell, { tableCellClasses } from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import Paper from '@mui/material/Paper';
import UploadIcon from '@mui/icons-material/Upload';
import { styled } from '@mui/material/styles';


const PersonSearch = () => {

    const initialSearchState = {dni: '', name: '', city: '' };
    const [search, setSearch] = useState(initialSearchState);

   
    const [personList, setPersonList] = useState([]);
    const handleInputChange = ev => { // funcion que se ejecuta al cambiar el input

        setSearch(
        {
            ...search,
            [ev.target.name] : ev.target.value
        });        

    };

    
    // Create ChangePersonList function
    const ChangePersonList = list => {

        setPersonList(list);
    };


    async function LoadFile(){
        const fileInput = document.querySelector('#contained-button-file');
        if(fileInput.files.length > 0){

            const formData  = new FormData();
            formData.append('file', fileInput.files[0]);

            const options = {
            method: 'POST',
            body: formData,
            // If you add this, upload won't work
            // headers: {
            //   'Content-Type': 'multipart/form-data',
            // }
            };

            try{
                const response = await fetch(`https://apireto.azure-api.net/retoApiPrueba/api/Person`, options);
            if(response.ok){
                alert("El archivo se cargo correctamente");
            }
            else{
                alert("Hubo un error en la información solicitada");
            }
            }catch(error){
                alert("Error: " + error);
            }
        }
    }
    async function handleEvent(dni, city, name){    
        try{   
            const response = await fetch(`https://apireto.azure-api.net/retoApiPrueba/api/Person?DNI=${dni}&Name=${name}&City=${city}`);
            if(response.ok){
                const result = await response.json();
                ChangePersonList(result);
            }
            else{
                alert("No existe la persona.");
            }
        }
        catch(error){
            alert("Error: " + error);
        }
        
    }

    const StyledTableRow = styled(TableRow)(({ theme }) => ({
        '&:nth-of-type(odd)': {
          backgroundColor: theme.palette.action.hover,
        },
        // hide last border
        '&:last-child td, &:last-child th': {
          border: 0,
        },
    }));

    const StyledTableCell = styled(TableCell)(({ theme }) => ({
        [`&.${tableCellClasses.head}`]: {
          backgroundColor: theme.palette.common.black,
          color: theme.palette.common.white,
        },
        [`&.${tableCellClasses.body}`]: {
          fontSize: 14,
        },
    }));

    return(
        <div style={{paddingTop:"10px"}}>
            <Grid container spacing={1} style={{justifyContent:"center", marginLeft:"5px", marginRight:"5px"}} columns={12}>
                <Grid item xs={6} md={6}>
                    <TextField  name="dni" type="number" label="DNI" onChange={handleInputChange}/>
                </Grid>

                <Grid item xs={6} md={6}>
                    <TextField  name="name" type="search" label="Nombre o apellido" onChange={handleInputChange}/>
                </Grid>

                <Grid item xs={12} md={12}>
                    <TextField  name="city" type="search" label="Localidad" onChange={handleInputChange}/>
                </Grid> 

                <Grid item xs={12} md={12} >
                    <Button variant="outlined" onClick={() => handleEvent(search.dni, search.city, search.name)} style={{margin:"5px"}} ><SearchIcon/></Button>
                    <input type="file" accept="application/vnd.openxmlformats-officedocument.spreadsheetml.sheet" style={{ display: 'none' }} onChange={() => LoadFile()} id="contained-button-file"/>
                    <label htmlFor="contained-button-file">
                        <Button style={{verticalAlign:"center"}} variant="outlined" component="span"><UploadIcon/></Button>
                    </label>
                </Grid>

            </Grid>

            <TableContainer component={Paper}>
                <Table>
                    <TableHead>
                        <TableRow>
                            <StyledTableCell>Nombre</StyledTableCell>
                            <StyledTableCell align="right">DNI</StyledTableCell>
                            <StyledTableCell align="right">Dirección</StyledTableCell>
                            <StyledTableCell align="right">Localidad</StyledTableCell>
                        </TableRow>
                    </TableHead>
                    <TableBody>
                        {personList.map((row, i) => (
                            <StyledTableRow
                            key={i}>
                            <StyledTableCell component="th" scope="row">
                                {row.fullName}
                            </StyledTableCell>
                            <StyledTableCell align="right">{row.dni}</StyledTableCell>
                            <StyledTableCell align="right">{row.address}</StyledTableCell>
                            <StyledTableCell align="right">{row.city}</StyledTableCell>
                            </StyledTableRow>
                        ))}
                    </TableBody>
                </Table>
            </TableContainer>
        </div>
    )

}

export default PersonSearch;