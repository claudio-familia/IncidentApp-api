export class DynamicForm {
    name: string
    value: any
    valueArray?: any[]
    valueFiltered?: any[]
    label: string
    type: string
    placeholder: string = ''   
    class?: string
    isRequired: boolean
    isDisabled: boolean = false
    hasError: boolean = false
    validationMessage?: string
}