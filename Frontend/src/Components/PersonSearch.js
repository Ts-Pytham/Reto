import React, { useState } from "react";
import Grid from '@mui/material/Unstable_Grid2';
import TextField from '@mui/material/TextField';
import Button from '@mui/material/Button';
import SearchIcon from '@mui/icons-material/Search';
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import Paper from '@mui/material/Paper';

const PersonSearch = (props) => {

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

    async function handleEvent(dni, city, name){        
        const response = await fetch(`https://localhost:7188/api/Person?DNI=${dni}&Name=${name}&City=${city}`);
        if(response.ok){
            const result = await response.json();

            ChangePersonList(result);
            console.log(result[0]);
        }
        else{
            alert("No existe la persona.");
        }
        
    }

    return(
        <div style={{paddingTop:"10px"}}>
            <Grid container spacing={2} style={{justifyContent:"center"}}>
                <Grid item xs={2} md={2}>
                    <TextField  name="dni" type="number" label="DNI" onChange={handleInputChange}/>
                </Grid>

                <Grid item xs={2} md={2}>
                    <TextField  name="name" type="search" label="Nombre o apellido" onChange={handleInputChange}/>
                </Grid>

                <Grid item xs={2} md={2}>
                    <TextField  name="city" type="search" label="localidad" onChange={handleInputChange}/>
                </Grid>

                <Grid item xs={2} md={2}>
                    <Button style={{verticalAlign:"center", marginTop:"10px", marginRight:"70px"}} onClick={() =>handleEvent(search.dni, search.city, search.name)} variant="outlined"><SearchIcon/></Button>
                </Grid>
            </Grid>
            <TableContainer component={Paper}>
                <Table  aria-label="simple table">
                    <TableHead>
                        <TableRow>
                            <TableCell>Nombre</TableCell>
                            <TableCell align="right">DNI</TableCell>
                            <TableCell align="right">Dirección</TableCell>
                            <TableCell align="right">Localidad</TableCell>
                        </TableRow>
                    </TableHead>
                    <TableBody>
                        {personList.map((row, i) => (
                            <TableRow
                            key={i}
                            sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
                            >
                            <TableCell component="th" scope="row">
                                {row.fullName}
                            </TableCell>
                            <TableCell align="right">{row.dni}</TableCell>
                            <TableCell align="right">{row.address}</TableCell>
                            <TableCell align="right">{row.city}</TableCell>
                            </TableRow>
                        ))}
                    </TableBody>
                </Table>
            </TableContainer>
        </div>
    )

}

export default PersonSearch;