import { useState } from "react";
import { Add, Remove } from "@mui/icons-material";
import { Button, Box, Dialog, DialogActions, DialogTitle, TextField, IconButton, DialogContent } from "@mui/material";
import { TRecipeCreateDto } from "types";

interface IRecipeDialogProps {
    onSubmit: (newRecipe: TRecipeCreateDto) => void;
    close: () => void;
}

const initialValues: TRecipeCreateDto = {
    name: "",
    ingredients: [],
    method: "",
}


/**
 * Recipe form component.
 */
export default function RecipeDialog({ onSubmit, close }: IRecipeDialogProps) {

    const [recipe, setRecipe] = useState<TRecipeCreateDto>(initialValues)

    const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        const { name, value } = e.currentTarget

        if (name === "name" || name === "method") {
            setRecipe({ ...recipe, [name]: value })
        } else {
            const ingredients: any = recipe.ingredients.slice()
            ingredients[Number(name.split(".")[0])][name.split(".")[1]] = value
            setRecipe({ ...recipe, ingredients })
        }
    }

    const handleCancel = () => {
        setRecipe(initialValues)
        close()
    }

    const addIngredient = () => {
        setRecipe({ ...recipe, ingredients: recipe.ingredients.concat({ amount: "", description: "" }) })
    }

    // Removes ingredient from specified index
    const removeIngredient = (index: number) => setRecipe({ ...recipe, ingredients: recipe.ingredients.filter((_, i) => i !== index) })

    return (
        <Dialog PaperProps={{
            sx: { width: '500px', minHeight: '600px' }
        }} open>
            <DialogTitle>
                Add new recipe
            </DialogTitle>
            <DialogContent>

                <Box sx={{ display: 'flex', flexDirection: 'column', p: 2 }}>
                    <TextField fullWidth sx={{ my: 1 }} onChange={handleChange} name="name" label="Name" />
                    <TextField
                        fullWidth
                        sx={{ my: 1 }}
                        label="Method"
                        multiline
                        minRows={6}
                        name="method"
                        onChange={handleChange}
                    />
                    {recipe.ingredients.map((i, index) => (
                        <div key={index} style={{ display: 'flex', alignItems: 'center' }}>
                            <TextField size="small" sx={{ mx: 1, my: 1 }} onChange={handleChange} value={i.amount} name={`${index}.amount`} label="Amount" />
                            <TextField size="small" sx={{ mx: 1, my: 1 }} onChange={handleChange} value={i.description} name={`${index}.description`} label="Description" />
                            <IconButton onClick={() => removeIngredient(index)}>
                                <Remove />
                            </IconButton>
                        </div>
                    ))}
                    <IconButton sx={{ width: 40 }} onClick={addIngredient}>
                        <Add />
                    </IconButton>


                </Box>

            </DialogContent>
            <DialogActions sx={{ mt: 'auto' }}>
                <Button onClick={(e) => onSubmit(recipe)}>Submit</Button>
                <Button type="button" onClick={handleCancel}>Cancel</Button>
            </DialogActions>
        </Dialog>
    )
}