import { CircularProgress, Typography } from "@mui/material"
import DefaultLayout from "layouts/DefaultLayout"
import { useParams } from "react-router-dom"
import { useGetRecipeByIdQuery } from "data/foodbApi"

interface IRecipeProps {

}

export default function Recipe(props: IRecipeProps) {

    const id = useParams().id

    const { data: recipe, isLoading, isSuccess } = useGetRecipeByIdQuery(id ? +id : 0)

    if (isLoading || !isSuccess) return <CircularProgress />

    return (
        <DefaultLayout>
            <Typography variant="h4">{recipe!.name}</Typography>

            <Typography sx={{ mt: 2 }} variant="h5">Ingredients</Typography>

            {recipe!.ingredients.map((i, index) => (
                <Typography key={index} variant="body1">{`${i.amount} ${i.description}`}</Typography>
            ))}

            <Typography sx={{ mt: 2 }} variant="h5">Method</Typography>
            <Typography variant="body1">{recipe!.method}</Typography>
        </DefaultLayout>
    )
}