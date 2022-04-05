import { Add, Delete } from "@mui/icons-material"
import { CircularProgress, Paper, TableBody, TableCell, TableHead, TableRow, Table, TableContainer, Typography, Button, IconButton } from "@mui/material"
import RecipeDialog from "components/dialog/RecipeDialog"
import DefaultLayout from "layouts/DefaultLayout"
import { useState } from "react"
import { Link } from "react-router-dom"
import { useAddRecipeMutation, useDeleteRecipeMutation, useGetRecipesQuery } from "data/foodbApi"
import { TRecipeCreateDto } from "types"
import { useAppSelector } from "utils/hooks"

export default function RecipeList() {
    const {
        data: recipes,
        isFetching,
        isLoading,
    } = useGetRecipesQuery()
    const [formOpen, setFormOpen] = useState(false)
    const authenticated = useAppSelector(state => state.auth.authenticated)
    const [addRecipe] = useAddRecipeMutation()
    const [deleteRecipe] = useDeleteRecipeMutation()

    const handleSubmit = ({ name, ingredients, method }: any) => {
        const newRecipe: TRecipeCreateDto = {
            name,
            ingredients,
            method,
        }

        addRecipe(newRecipe)
        setFormOpen(false)
    }

    const handleDelete = (id: number) => {
        window.confirm('Sure thing?') && deleteRecipe(id)
    }

    if (isFetching || isLoading) return <CircularProgress />

    return (
        <DefaultLayout>
            <Typography variant="h4">Recipe list</Typography>
            <TableContainer sx={{ mt: 2 }} component={Paper}>
                <Table sx={{ minWidth: 650 }} size="small" aria-label="a dense table">
                    <TableHead>
                        <TableRow>
                            <TableCell>Name</TableCell>
                            <TableCell align="right">Id</TableCell>
                            <TableCell align="right">Ingredients</TableCell>
                            {authenticated && <TableCell align="right">Actions</TableCell>}
                        </TableRow>
                    </TableHead>
                    <TableBody>
                        {(recipes || []).map((recipe) => (
                            <TableRow
                                key={recipe.id}
                                sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
                            >
                                <TableCell component="th" scope="row">
                                    <Link to={`/recipe/${recipe.id}`}>{recipe.name}</Link>
                                </TableCell>
                                <TableCell align="right">{recipe.id}</TableCell>
                                <TableCell align="right">{recipe.ingredients.length}</TableCell>
                                {authenticated && <TableCell align="right">
                                    <IconButton onClick={() => handleDelete(recipe.id)}>
                                        <Delete />
                                    </IconButton>
                                </TableCell>}
                            </TableRow>
                        ))}
                    </TableBody>
                </Table>
            </TableContainer>
            <Button startIcon={<Add />} onClick={() => setFormOpen(true)}>Add new</Button>
            {formOpen && (
                <RecipeDialog onSubmit={handleSubmit} close={() => setFormOpen(false)} />
            )}
        </DefaultLayout>
    )
}