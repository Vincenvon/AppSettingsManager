import styled from 'styled-components';

export const Container = styled.div`
    height: 100%;
    width: 100%;
`;

export const FormContainer = styled.div`
    width: 50%;
    height: 50%;
    display: flex;
    flex-direction: column;
`;

export const Form = styled.form`    
    display: flex;
    flex-direction: column;
`;

export const UserName = styled.input.attrs(() => ({
    required: true,
}))`
    margin-top: 16px;
    font: inherit;
    color: currentColor;
    width: 100%;
    border: 0;
    height: 1.1876em;
    margin: 0;
    display: block;
    padding: 6px 0 7px;
    min-width: 0;
    background: none;
    box-sizing: content-box;
    animation-name: mui-auto-fill-cancel;
    letter-spacing: inherit;
    animation-duration: 10ms;
`;

export const Password = styled.input.attrs(() => ({
    type: "password",
    required: "true"
}))`
    margin-top: 16px;
`;
