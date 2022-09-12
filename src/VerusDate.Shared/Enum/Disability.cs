using VerusDate.Shared.Core;

namespace VerusDate.Shared.Enum
{
    /// <summary>
    /// https://www.academia.edu/39976315/6_General_Types_Of_Disabilities_Physical_Disabilities
    /// </summary>
    public enum Disability
    {
        [Custom(Name = "Physical", Description = "Includes physiological, functional and/or mobility impairments. Can be fluctuating or intermittent, chronic, progressive or stable, visible or invisible.")]
        Physical = 1,

        [Custom(Name = "Visual", Description = "“Legally Blind” describes an individual who has 10% or less of normal vision. Only 10% of people with a visual disability are actually totally blind. The other 90% are described as having a “Visual Impairment.”")]
        Visual = 2,

        [Custom(Name = "Hearing", Description = "“Deaf” describes an individual who has severe to profound hearing loss. “Deafened” describes an individual who has acquired a hearing loss in adulthood.")]
        Hearing = 3,

        [Custom(Name = "Mental Health", Description = "Mental health disabilities can take many forms, just as physical disabilities do. They are generally classified into six categories: Schizophrenia, Mood Disorders, Anxiety Disorders, Eating Disorders, Personality Disorders, Organic Brain Disorders.")]
        MentalHealth = 4,

        [Custom(Name = "Intellectual", Description = "Characterized by intellectual development and capacity that is significantly below average. Involves a permanent limitation in a person’s ability to learn.")]
        Intellectual = 5,

        [Custom(Name = "Learning", Description = "A learning disability is essentially a specific and persistent disorder of a person’s central nervous system affecting the learning process. This impacts a person’s ability to either interpret what they see and hear, or to link information from different parts of the brain.")]
        Learning = 6,
    }
}