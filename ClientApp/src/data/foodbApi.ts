import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react'
import { IAuthCredentials, IRecipe, TRecipeCreateDto } from 'types'
import { RootState } from './store'

const baseUrl = document.getElementsByTagName('base')[0].getAttribute('href') as string;

export const foodbApi = createApi({
    reducerPath: 'foodbApi',
    baseQuery: fetchBaseQuery({
        baseUrl: `${baseUrl}/api`,
        prepareHeaders: (headers, { getState }) => {
            const token = (getState() as RootState).auth.access_token
            // If we have a token set in state, let's assume that we should be passing it.
            if (token) {
                headers.set('authorization', `Bearer ${token}`)
            }
            return headers
        },
    }),
    tagTypes: ['Recipe'],
    endpoints: (build) => ({
        getRecipes: build.query<IRecipe[], void>({
            query: () => '/recipes',
            providesTags: (result, error, arg) =>
                result
                    ? [...result.map(({ id }) => ({ type: 'Recipe' as const, id })), 'Recipe']
                    : ['Recipe'],

        }),
        getRecipeById: build.query<IRecipe, number>({
            query: (id) => `/recipes/${id}`,
            providesTags: (result, error, arg) => [{ type: 'Recipe' as const, id: arg }]
        }),
        addRecipe: build.mutation<IRecipe, TRecipeCreateDto>({
            query: (recipe) => ({
                method: 'POST',
                url: '/recipes',
                body: recipe
            }),
            invalidatesTags: ['Recipe'],
        }),
        deleteRecipe: build.mutation<void, number>({
            query: (id) => ({
                method: 'DELETE',
                url: `/recipes/${id}`,
            }),
            invalidatesTags: ['Recipe'],
        }),
        login: build.mutation<{ access_token: string }, IAuthCredentials>({
            query: (credentials) => ({
                method: 'POST',
                url: '/login',
                body: credentials
            }),
        }),
        signUp: build.mutation<void, IAuthCredentials>({
            query: (credentials) => ({
                method: 'POST',
                url: '/users',
                body: credentials
            }),
        }),
    }),
})

export const {
    useGetRecipesQuery,
    useGetRecipeByIdQuery,
    useAddRecipeMutation,
    useLoginMutation,
    useDeleteRecipeMutation,
    useSignUpMutation
} = foodbApi