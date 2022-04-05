export interface IIngredient {
    id: number;
    amount: string;
    description: string;
}

type TIngredientCreateDto = Omit<IIngredient, 'id'>

export interface IRecipe {
    id: number
    name: string
    method: string
    ingredients: IIngredient[]
}

export type TRecipeCreateDto = Pick<IRecipe, 'name' | 'method'> & {
    ingredients: TIngredientCreateDto[]
}

export interface IAuthSuccessResponse {
    access_token: string
}

export interface IAuthCredentials {
    username: string
    password: string
}